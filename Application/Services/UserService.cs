namespace SuplementShop.Application.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Application.Responses;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IUserRepo UserRepo;

        private readonly IConfiguration Config;
        public UserService(IUserRepo userRepo, IConfiguration config)
        {
            UserRepo = userRepo;
            Config = config;
        }

        public async Task<TokenResponse> LogInAsync(LogInRequest request)
        {
            User user = await AuthenticateUserAsync(request);

            if (user == null)
            {
                return new TokenResponse
                {
                    Token = null
                };
            }

            string token = GenerateJSONWebToken(user);

            return new TokenResponse
            {
                Token = token
            };
        }

        public async Task<string> SignUpAsync(SignUpRequest request)
        {
            User user = User.Create(default, request.Email, request.Name, request.Password);

            await UserRepo.CreateUserAsync(user);

            return "User created successfully. You can log in now.";
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Name),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Sid, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(Config["Jwt:Issuer"],
              Config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> AuthenticateUserAsync(LogInRequest login)
        {
            User user = await UserRepo.GetUserByEmailAsync(login.Email);

            if (user == null || user.Password != login.Password)
            {
                return null;
            }

            return user;
        }
    }
}
