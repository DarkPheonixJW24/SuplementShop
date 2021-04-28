namespace SuplementShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Web.Extensions;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            var result = await UserService.SignUpAsync(request);

            return this.ToResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("log-in")]
        public async Task<IActionResult> SignIn([FromBody] LogInRequest request)
        {
            var result = await UserService.LogInAsync(request);

            return this.ToResult(result);
        }

        [HttpGet]
        public IActionResult GetSelf()
        {
            var loggedInUserId = User.GetLoggedInUserId();
            var role = User.GetUserRole();
            if (loggedInUserId == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(role);
            }
        }
    }
}
