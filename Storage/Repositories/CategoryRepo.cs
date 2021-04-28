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
                ImageUrl = "https://missouribusinessalert.com/wp-content/uploads/2015/05/three-ice-cubes.jpg",
                Name = "Ice"
            });

            Categories.AddOrUpdate(new Category
            {
                Id = 2,
                ImageUrl = "https://antoinesoto.com/photolux/wp-content/uploads/2012/07/balls.jpg",
                Name = "Balls"
            });

            context.SaveChanges();
        }
    }
}
