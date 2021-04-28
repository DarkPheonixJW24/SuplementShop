namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Category> AddCategory(Category category)
        {
            return await categoryRepo.CreateCategory(category);
        }

        public async Task<IEnumerable<Category>> ListAllCategories()
        {
            return await categoryRepo.ListCategories();
        }
    }
}
