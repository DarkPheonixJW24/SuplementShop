namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<Cart> AddCartItem(int cartId, CartItem cartItem);
        Task<Cart> Buy(int cartId, int userId);
        Task<Cart> Clear(int cartId);
        Task<Cart> Decrement(int cartId, int productId);
        Task<Cart> GetOrCreateCartForUser(int userId);
        Task<Cart> Increment(int cartId, int productId);
        Task<IEnumerable<Cart>> ListCartsForUser(int userId);
        Task<Cart> RemoveCartItem(int cartId, int productId);
    }
}
