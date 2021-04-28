namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<Response<Product>> GetProduct(int id);

        Task<Response<IEnumerable<Product>>> GetProductsForCategory(string name);

        Task<Response<List<Product>>> GetAllByMannufacturer(string mannufacturer);

        Task<Response<List<Product>>> SearchProducts(string searchTerm);

        Task<Response<ICollection<Product>>> GetProducts();

        Task<Response<string>> CreateProduct(CreateProductRequest request);

        Task<Response<string>> UpdateProduct(int id, UpdateProductRequest request);

        Task<Response<string>> DeleteProduct(int id);
    }
}
