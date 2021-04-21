namespace SuplementShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Web.Extensions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetOrCreateCartForUser()
        {
            var userId = User.GetLoggedInUserId();

            if(userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.GetOrCreateCartForUser(userId.Value);
            return Ok(result);
        }

        [HttpGet("buy/{cartId}")]
        public async Task<IActionResult> Buy([FromRoute] int cartId)
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.Buy(cartId, userId.Value);
            return Ok(result);
        }

        [HttpGet("clear/{cartId}")]
        public async Task<IActionResult> Clear([FromRoute] int cartId)
        {
            var result = await cartService.Clear(cartId);
            return Ok(result);
        }

        [HttpPost("cartItem/{cartId}")]
        public async Task<IActionResult> AddCartItem([FromRoute] string cartId, [FromBody] CartItem cartItem)
        {
            var result = await cartService.AddCartItem(cartId, cartItem);
            return Ok(result);
        }

        [HttpDelete("cartItem/{cartId}/{productId}")]
        public async Task<IActionResult> RemoveCartItem([FromRoute] string cartId, [FromRoute]  string productId)
        {
            var result = await cartService.RemoveCartItem(cartId, productId);
            return Ok(result);
        }

        [HttpGet("increment/{cartId}/{productId}")]
        public async Task<IActionResult> IncrementProduct([FromRoute] string productId, [FromRoute] string cartId)
        {
            var result = await cartService.Increment(cartId, productId);
            return Ok(result);
        }

        [HttpGet("decrement/{cartId}/{productId}")]
        public async Task<IActionResult> DecrementProduct([FromRoute] string productId, [FromRoute] string cartId)
        {
            var result = await cartService.Decrement(cartId, productId);
            return Ok(result);
        }

        [HttpGet("list/{userId}")]
        public async Task<IActionResult> ListCarts([FromRoute] string userId)
        {
            var result = await cartService.ListCartsForUser(userId);
            return Ok(result);
        }
    }
}