namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    private interface ICartRepo
    {
        Task<Cart> GetCart(string id);

        Task<ICollection<Cart>> GetProducts();

        Task<bool> DeleteProduct(int id);
    }
}