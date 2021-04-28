namespace SuplementShop.Application.Services
{
    using Stripe;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly ICartRepo cartRepo;
        private readonly ICartItemRepo cartItemRepo;
        private readonly IProductRepo productRepo;
        private readonly ChargeService chargeService;

        public CartService(ICartRepo cartRepo,
                           ICartItemRepo cartItemRepo,
                           IProductRepo productRepo,
                           ChargeService chargeService)
        {
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.productRepo = productRepo;
            this.chargeService = chargeService;
        }

        public async Task<Response<Cart>> GetOrCreateCartForUser(int userId)
        {
            Cart cart = await cartRepo.GetActiveCartForUser(userId);

            if (cart != null)
            {
                return Response<Cart>.Ok(cart);
            }

            cart = new Cart
            {
                Id = default,
                CartStatus = CartStatus.Active,
                ChargeId = default,
                UserId = userId
            };

            var response = await cartRepo.CreateCart(cart);
            return Response<Cart>.Ok(response);
        }

        public async Task<Response<Cart>> AddCartItem(int userId, int cartId, int productId)
        {
            Cart cart = await cartRepo.GetCart(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            Entities.Product product = await productRepo.GetProduct(productId);

            if (product == null)
            {
                return Response<Cart>.Error("Product not found");
            }

            if (product.Stock < 1)
            {
                return Response<Cart>.Error("Product not in stock");
            }

            CartItem cartItem = new CartItem
            {
                CartId = cartId,
                Count = 1,
                Price = product.Price,
                ProductId = productId,
                ProductName = product.Name
            };

            await cartItemRepo.CreateCartItem(cartItem);

            cart = await cartRepo.GetCart(userId, cartId);

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<Cart>> Buy(int userId, BuyCartRequest request)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, request.CartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            if (cart.CartItems.Any(x => x.Count > x.Product.Stock))
            {
                return Response<Cart>.Error("Product not in stock");
            }

            ChargeCreateOptions options = new ChargeCreateOptions
            {
                Amount = cart.CartItems.Sum(x => x.Price * x.Count),
                Currency = "mkd",
                Source = request.Token
            };

            Charge charge = chargeService.Create(options);

            if (charge.Status != "succeeded")
            {
                return Response<Cart>.Error("Payment failed");
            }

            cart.CartStatus = CartStatus.Bought;
            cart.ChargeId = charge.Id;

            await cartRepo.UpdateCart(cart);

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<Cart>> Clear(int userId, int cartId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            foreach (CartItem item in cart.CartItems)
            {
                await cartItemRepo.DeleteCartItem(item.Id);
            }

            cart.CartItems.Clear();

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<Cart>> Decrement(int userId, int cartId, int cartItemId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);


            if (cartItem == null)
            {
                return Response<Cart>.Error("Item not found");
            }

            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                await cartItemRepo.UpdateCartItem(cartItem);
            }
            else
            {
                await cartItemRepo.DeleteCartItem(cartItemId);
                cart.CartItems.Remove(cartItem);
            }

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<Cart>> Increment(int userId, int cartId, int cartItemId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);

            if (cartItem == null)
            {
                return Response<Cart>.Error("Item not found");
            }

            cartItem.Count++;
            await cartItemRepo.UpdateCartItem(cartItem);

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<IEnumerable<Cart>>> ListCartsForUser(int userId)
        {
            var response = await cartRepo.GetAllCartsForUser(userId);

            return Response<IEnumerable<Cart>>.Ok(response);
        }

        public async Task<Response<Cart>> RemoveCartItem(int userId, int cartId, int cartItemId)
        {

            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                return Response<Cart>.Error("Invalid cart");
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);

            if (cartItem == null)
            {
                return Response<Cart>.Error("Item not found");
            }

            await cartItemRepo.DeleteCartItem(cartItemId);

            cart.CartItems.Remove(cartItem);

            return Response<Cart>.Ok(cart);
        }

        public async Task<Response<Charge>> TestCharge()
        {
            ChargeCreateOptions options = new ChargeCreateOptions
            {
                Amount = 100,
                Currency = "mkd",
                Source = "tok_visa", // This is the user token
                ReceiptEmail = "hello_dotnet@example.com",
            };

            Charge charge = await chargeService.CreateAsync(options);

            return Response<Charge>.Ok(charge);
        }
    }
}
