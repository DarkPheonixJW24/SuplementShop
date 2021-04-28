namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Response<Category>> AddCategory(Category category)
        {
            var response = await categoryRepo.CreateCategory(category);
            return Response<Category>.Ok(response);
        }

        public async Task<Response<IEnumerable<Category>>> ListAllCategories()
        {
            var response = await categoryRepo.ListCategories();
            return Response<IEnumerable<Category>>.Ok(response);
        }
    }
}
