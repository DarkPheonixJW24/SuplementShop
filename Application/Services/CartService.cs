namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly ICartRepo cartRepo;
        private readonly ICartItemRepo cartItemRepo;
        private readonly IProductRepo productRepo;

        public CartService(ICartRepo cartRepo, ICartItemRepo cartItemRepo, IProductRepo productRepo)
        {
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.productRepo = productRepo;
        }

        public async Task<Cart> GetOrCreateCartForUser(int userId)
        {
            Cart cart = await cartRepo.GetActiveCartForUser(userId);

            if (cart != null)
            {
                return cart;
            }

            cart = new Cart
            {
                Id = default,
                CartStatus = CartStatus.Active,
                PaymentId = default,
                UserId = userId
            };

            return await cartRepo.CreateCart(cart);
        }

        public async Task<Cart> AddCartItem(int userId, int cartId, int productId)
        {
            Cart cart = await cartRepo.GetCart(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            Product product = await productRepo.GetProduct(productId);

            if (product == null)
            {
                throw new NotImplementedException();
            }

            if (product.Stock < 1)
            {
                throw new NotImplementedException();
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

            return cart;
        }

        public async Task<Cart> Buy(int userId, int cartId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            if (cart.CartItems.Any(x => x.Count > x.Product.Stock))
            {
                throw new NotImplementedException();
            }

            // Insert stripe code here

            cart.CartStatus = CartStatus.Bought;

            await cartRepo.UpdateCart(cart);

            return cart;
        }

        public async Task<Cart> Clear(int userId, int cartId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            foreach (CartItem item in cart.CartItems)
            {
                await cartItemRepo.DeleteCartItem(item.Id);
            }

            cart.CartItems.Clear();

            return cart;
        }

        public async Task<Cart> Decrement(int userId, int cartId, int cartItemId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);


            if (cartItem == null)
            {
                throw new NotImplementedException();
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

            return cart;
        }

        public async Task<Cart> Increment(int userId, int cartId, int cartItemId)
        {
            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);

            if (cartItem == null)
            {
                throw new NotImplementedException();
            }

            cartItem.Count++;
            await cartItemRepo.UpdateCartItem(cartItem);

            return cart;
        }

        public async Task<IEnumerable<Cart>> ListCartsForUser(int userId)
        {
            return await cartRepo.GetAllCartsForUser(userId);
        }

        public async Task<Cart> RemoveCartItem(int userId, int cartId, int cartItemId)
        {

            Cart cart = await cartRepo.GetCartWithProducts(userId, cartId);

            if (cart.CartStatus != CartStatus.Active)
            {
                throw new NotImplementedException();
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);

            if (cartItem == null)
            {
                throw new NotImplementedException();
            }

            await cartItemRepo.DeleteCartItem(cartItemId);

            cart.CartItems.Remove(cartItem);

            return cart;
        }
    }
}
