namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
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

        public async Task<Response<Product>> GetProduct(int id)
        {
            var response = await repo.GetProduct(id);
            return Response<Product>.Ok(response);
        }

        public async Task<Response<ICollection<Product>>> GetProducts()
        {
            var response = await repo.GetProducts();
            return Response<ICollection<Product>>.Ok(response);
        }

        public async Task<Response<string>> CreateProduct(CreateProductRequest request)
        {
            if(request.Stock < 0)
            {
                return Response<string>.Error("Stock cant be less then zero you dumb fuck");
            }

            if(request.Price < 0)
            {
                return Response<string>.Error("This aint no charity you dumb fuck");
            }

            Product product = new Product
            {
                Id = default,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Stock = request.Stock,
                ImagesUrls = request.Images
            };

            await repo.CreateProduct(product);

            return Response<string>.Ok(string.Empty);
        }

        public async Task<Response<string>> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (request.Stock < 0)
            {
                return Response<string>.Error("Stock cant be less then zero you dumb fuck");
            }

            if (request.Price < 0)
            {
                return Response<string>.Error("This aint no charity you dumb fuck");
            }

            Product product = await repo.GetProduct(id);

            if (product == null)
            {
                return Response<string>.Error("Not found");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.ImagesUrls = request.Images;

            await repo.UpdateProduct(id, product);

            return Response<string>.Ok(string.Empty);
        }

        public async Task<Response<string>> DeleteProduct(int id)
        {
            var response = await repo.DeleteProduct(id);
            return Response<string>.Ok("Deleted");
        }

        public Task<Response<IEnumerable<Product>>> GetProductsForCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Product>>> GetAllByMannufacturer(string mannufacturer)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Product>>> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
