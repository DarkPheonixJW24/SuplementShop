namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepo
    {
        Task<Product> GetProduct(int id);

        Task<ICollection<Product>> GetProducts();

        Task<ICollection<Product>> GetProductsByCategory(string category);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(int id, Product product);

        Task<bool> DeleteProduct(int id);
        
        void FillDb();
    }
}
