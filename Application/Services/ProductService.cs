namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await repo.GetProduct(id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await repo.GetProducts();
        }

        public async Task<string> CreateProduct(CreateProductRequest request)
        {
            if(request.Stock < 0)
            {
                return "Stock cant be less then zero you dumb fuck";
            }

            if(request.Price < 0)
            {
                return "This aint no charity you dumb fuck";
            }

            Product product = new Product
            {
                Id = default,
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Price = request.Price,
                Stock = request.Stock,
                Images = request.Images
            };

            await repo.CreateProduct(product);

            return string.Empty;
        }

        public async Task<string> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (request.Stock < 0)
            {
                return "Stock cant be less then zero you dumb fuck";
            }

            if (request.Price < 0)
            {
                return "This aint no charity you dumb fuck";
            }

            Product product = await repo.GetProduct(id);

            if (product == null)
            {
                return "Not found";
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.Images = request.Images;

            await repo.UpdateProduct(id, product);

            return string.Empty;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await repo.DeleteProduct(id);
        }
    }
}
