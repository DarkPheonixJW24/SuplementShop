namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICartRepo
    {
        Task<Cart> GetCart(int userId, int id);

        Task<Cart> GetCartWithProducts(int userId, int id);

        Task<Cart> GetActiveCartForUser(int userId);

        Task<List<Cart>> GetAllCartsForUser(int userId);

        Task<Cart> CreateCart(Cart cart);

        Task UpdateCart(Cart cart);

        Task DeleteCart(int userId, int cartId);
        
        Task<List<Cart>> GetProcessingCartsForUser(int userId);
    }
}