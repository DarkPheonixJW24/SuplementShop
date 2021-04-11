namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepo : IProductRepo
    {
        private readonly MyDbContext context;

        private DbSet<Product> Products => context.Set<Product>();

        public ProductRepo(MyDbContext ctx)
        {
            context = ctx;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await Products.AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            EntityEntry<Product> result = await Products.AddAsync(product);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var entity = context.Entry(product);

            entity.CurrentValues.SetValues(product);

            await context.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await GetProduct(id);

            if (product == null)
            {
                return false;
            }

            Products.Remove(product);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
