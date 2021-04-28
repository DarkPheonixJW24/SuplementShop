namespace SuplementShop.Application.Interfaces
{
    using Stripe;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<Response<Cart>> AddCartItem(int userId, int cartId, int productId);
        Task<Response<Cart>> Buy(int userId, BuyCartRequest request);
        Task<Response<Cart>> Clear(int userId, int cartId);
        Task<Response<Cart>> Decrement(int userId, int cartId, int cartItemId);
        Task<Response<Cart>> GetOrCreateCartForUser(int userId);
        Task<Response<Cart>> Increment(int userId, int cartId, int cartItemId);
        Task<Response<IEnumerable<Cart>>> ListCartsForUser(int userId);
        Task<Response<Cart>> RemoveCartItem(int userId, int cartId, int cartItemId);
        Task<Response<Charge>> TestCharge();
    }
}
