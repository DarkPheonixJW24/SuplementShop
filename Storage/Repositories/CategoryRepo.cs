namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryRepo : ICategoryRepo
    {
        private readonly MyDbContext context;

        private DbSet<Category> Categories => context.Set<Category>();

        public CategoryRepo(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            EntityEntry<Category> result = await Categories.AddAsync(category);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<Category>> ListCategories()
        {
            return await Categories.ToListAsync();
        }

        public void FillDb()
        {
            Categories.AddOrUpdate(new Category
            {
                Id = 1,
                ImageUrl = "https://gymbeam.com/media/catalog/product/cache/926507dc7f93631a094422215b778fe0/g/o/gold_titulna.png",
                Name = "Protein"
            });

            Categories.AddOrUpdate(new Category
            {
                Id = 2,
                ImageUrl = "https://secec.org/wp-content/uploads/2019/11/Gorilla-Mind-Rush-Review.png",
                Name = "Preworkout"
            });

            Categories.AddOrUpdate(new Category
            {
                Id = 3,
                ImageUrl = "https://www.yamamotonutrition.com/imgp/big/a31498.jpg",
                Name = "Creatinе"
            });

            Categories.AddOrUpdate(new Category
            {
                Id = 4,
                ImageUrl = "https://gymbeam.com/media/catalog/product/cache/926507dc7f93631a094422215b778fe0/m/u/mutant_mass_2270.jpg",
                Name = "Gainer"
            });

            Categories.AddOrUpdate(new Category
            {
                Id = 5,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71gWzXYET4L._AC_SL1500_.jpg",
                Name = "Fat Burners"
            });

            context.SaveChanges();
        }
    }
}
