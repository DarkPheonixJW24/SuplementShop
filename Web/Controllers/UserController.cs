namespace SuplementShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using System.Threading.Tasks;

    [ApiController]
    [AllowAnonymous]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            string result = await UserService.SignUpAsync(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("log-in")]
        public async Task<IActionResult> SignIn([FromBody] LogInRequest request)
        {
            var result = await UserService.LogInAsync(request);

            return Ok(result);
        }


    }
}
