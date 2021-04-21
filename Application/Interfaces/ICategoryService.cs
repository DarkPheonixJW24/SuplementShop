namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAllCategories();
        Task<Category> AddCategory(Category category);
    }
}
