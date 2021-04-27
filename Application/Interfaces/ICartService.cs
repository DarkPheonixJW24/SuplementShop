namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<Cart> AddCartItem(int userId, int cartId, int productId);
        Task<Cart> Buy(int userId, int cartId);
        Task<Cart> Clear(int userId, int cartId);
        Task<Cart> Decrement(int userId, int cartId, int cartItemId);
        Task<Cart> GetOrCreateCartForUser(int userId);
        Task<Cart> Increment(int userId, int cartId, int cartItemId);
        Task<IEnumerable<Cart>> ListCartsForUser(int userId);
        Task<Cart> RemoveCartItem(int userId, int cartId, int cartItemId);
    }
}
