namespace SuplementShop.Application.Interfaces
{
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<Response<string>> SignUpAsync(SignUpRequest request);

        Task<Response<TokenResponse>> LogInAsync(LogInRequest request);
    }
}
