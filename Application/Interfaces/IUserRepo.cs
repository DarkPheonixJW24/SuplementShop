namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Entities;
    using System.Threading.Tasks;

    public interface IUserRepo
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<int> CreateUserAsync(User user);
        
        void FillDb();
    }
}
