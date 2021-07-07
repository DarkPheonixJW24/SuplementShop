namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<ICollection<Product>> GetProductsByCategory(string category)
        {
            return await Products.AsNoTracking().Include(x => x.Category).Where(x => x.Category.Name == category).ToListAsync();
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

        public void FillDb()
        {
            for (int i = 1; i < 60; i++)
            {
                Products.AddOrUpdate(new Product
                {
                    Id = i,
                    CategoryId = 1,
                    Description = $"Whey {i}",
                    ImageUrls = new List<string>() {
                        "https://gymbeam.com/media/catalog/product/cache/926507dc7f93631a094422215b778fe0/g/o/gold_titulna.png"
                    },
                    Name = $"Whey {i}",
                    Price = 100 + i * 25,
                    Stock = 10,
                    Manufacturer = "Manufacturer"
                });
            }

            for (int i = 1; i < 60; i++)
            {
                Products.AddOrUpdate(new Product
                {
                    Id = i+59,
                    CategoryId = 2,
                    Description = $"Gorilla Mind Rush {i}",
                    ImageUrls = new List<string>() {
                        "https://secec.org/wp-content/uploads/2019/11/Gorilla-Mind-Rush-Review.png"
                    },
                    Name = $"Gorilla Mind Rush {i}",
                    Price = 100 + i * 25,
                    Stock = 10,
                    Manufacturer = "Manufacturer"
                });
            }

            for (int i = 1; i < 60; i++)
            {
                Products.AddOrUpdate(new Product
                {
                    Id = i + (59 *2),
                    CategoryId = 3,
                    Description = $"One Protein {i}",
                    ImageUrls = new List<string>() {
                        "https://www.yamamotonutrition.com/imgp/big/a31498.jpg"
                    },
                    Name = $"One Protein {i}",
                    Price = 100 + i * 25,
                    Stock = 10,
                    Manufacturer = "Manufacturer"
                });
            }

            for (int i = 1; i < 60; i++)
            {
                Products.AddOrUpdate(new Product
                {
                    Id = i + (59 * 3),
                    CategoryId = 4,
                    Description = $"Mutant Mass {i}",
                    ImageUrls = new List<string>() {
                        "https://gymbeam.com/media/catalog/product/cache/926507dc7f93631a094422215b778fe0/m/u/mutant_mass_2270.jpg"
                    },
                    Name = $"Mutant Mass {i}",
                    Price = 100 + i * 25,
                    Stock = 10,
                    Manufacturer = "Manufacturer"
                });
            }

            for (int i = 1; i < 60; i++)
            {
                Products.AddOrUpdate(new Product
                {
                    Id = i + (59 * 4),
                    CategoryId = 5,
                    Description = $"Keto {i}",
                    ImageUrls = new List<string>() {
                        "https://images-na.ssl-images-amazon.com/images/I/71gWzXYET4L._AC_SL1500_.jpg"
                    },
                    Name = $"Keto {i}",
                    Price = 100 + i * 25,
                    Stock = 10,
                    Manufacturer = "Manufacturer"
                });
            }

            context.SaveChanges();
        }
    }
}
