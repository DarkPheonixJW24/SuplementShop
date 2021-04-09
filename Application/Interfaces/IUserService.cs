namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<string> SignUpAsync(SignUpRequest request);

        Task<TokenResponse> LogInAsync(LogInRequest request);
    }
}
