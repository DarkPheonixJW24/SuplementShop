namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly ICartRepo repo;

        public CartService(ICartRepo repo)
        {
            this.repo = repo;
        }

        public async Task<Cart> GetOrCreateCartForUser(int userId)
        {
            Cart cart = await repo.GetActiveCartForUser(userId);

            if(cart != null)
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

            await repo.CreateCart(cart);
        }

        public Task<Cart> AddCartItem(int userId, int cartId, CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Buy(int userId, int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Clear(int userId, int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Decrement(int userId, int cartId, int productId)
        {
            throw new NotImplementedException();
        }


        public Task<Cart> Increment(int userId, int cartId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> ListCartsForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> RemoveCartItem(int userId, int cartId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
