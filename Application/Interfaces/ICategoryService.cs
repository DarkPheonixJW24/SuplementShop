namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<Response<IEnumerable<Category>>> ListAllCategories();
        Task<Response<Category>> AddCategory(Category category);
    }
}
