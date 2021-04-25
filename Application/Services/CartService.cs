namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
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

        public async Task<Cart> AddCartItem(int CartId, CartItem cartItem)
        {
            if (CartId != null)
            {
                this.cartItem = await.repo.GetProduct();
            }
           
        }

        public async Task<Cart> AddCartItem(int CartId, CartItem cartItem)
        {
            if (CartId != null)
            {
                this.cartItem = await.repo.GetProduct();
            }

        }






    }
}
