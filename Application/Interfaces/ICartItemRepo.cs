namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Threading.Tasks;

    public interface ICartItemRepo
    {
        public Task<CartItem> GetCartItemById(int id);
        public Task<CartItem> CreateCartItem(CartItem cartItem);
        public Task UpdateCartItem(CartItem cartItem);
        public Task DeleteCartItem(int id);
    }
}
