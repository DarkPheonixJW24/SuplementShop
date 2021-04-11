namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Requests;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<Product> GetProduct(int id);

        Task<ICollection<Product>> GetProducts();

        Task<string> CreateProduct(CreateProductRequest request);

        Task<string> UpdateProduct(int id, UpdateProductRequest request);

        Task<bool> DeleteProduct(int id);
    }
}
