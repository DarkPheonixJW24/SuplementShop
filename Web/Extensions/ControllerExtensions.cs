namespace SuplementShop.Web.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Responses;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;

    public static class ControllerExtensions
    {
        public static int? GetLoggedInUserId(this ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sid)?.Value;

            if (id == null)
            {
                return null;
            }
            else
            {
                return int.Parse(id);
            }
        }

        public static Role? GetUserRole(this ClaimsPrincipal user)
        {
            var role = user.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Nonce)?.Value;

            if (role == null)
            {
                return null;
            }
            else
            {
                return Enum.Parse<Role>(role);
            }
        }

        public static IActionResult ToResult<T>(this ControllerBase c, Response<T> response) where T : class
        {
            if (response.Message.Length == 0)
            {
                return c.Ok(response.Value);
            }
            else
            {
                return c.BadRequest(response.Message);
            }
        }
    }
}
