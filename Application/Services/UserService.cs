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

        public async Task<Response<TokenResponse>> LogInAsync(LogInRequest request)
        {
            User user = await AuthenticateUserAsync(request);

            if (user == null)
            {
                return Response<TokenResponse>.Error("Login failed");
            }

            string token = GenerateJSONWebToken(user);

            return Response<TokenResponse>.Ok(new TokenResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Token = token
            });
        }

        public async Task<Response<string>> SignUpAsync(SignUpRequest request)
        {
            // Check request
            User user = User.Create(default, request.Email, request.FullName, request.Password, Role.User);

            await UserRepo.CreateUserAsync(user);

            return Response<string>.Ok("User created successfully. You can log in now.");
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.FullName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Sid, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nonce, userInfo.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(Config["Jwt:Issuer"],
              Config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddYears(120),
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
