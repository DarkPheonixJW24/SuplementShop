namespace SuplementShop.Web.Extensions
{
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
    }
}
