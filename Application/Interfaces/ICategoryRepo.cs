namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRepo
    {
        public Task<Category> CreateCategory(Category category);
        public Task<List<Category>> ListCategories();
        void FillDb();
    }
}
