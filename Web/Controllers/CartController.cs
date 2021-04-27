﻿namespace SuplementShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Web.Extensions;
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

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.GetOrCreateCartForUser(userId.Value);
            return Ok(result);
        }

        [HttpGet("buy/{cartId:int}")]
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

        [HttpGet("clear/{cartId:int}")]
        public async Task<IActionResult> Clear([FromRoute] int cartId)
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.Clear(userId.Value, cartId);
            return Ok(result);
        }

        [HttpPost("cartItem/{cartId:int}")]
        public async Task<IActionResult> AddCartItem([FromRoute] int cartId, [FromBody] AddCartItemRequest request)
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.AddCartItem(userId.Value, cartId, request.ProductId);
            return Ok(result);
        }

        [HttpDelete("cartItem/{cartId:int}/{cartItemId:int}")]
        public async Task<IActionResult> RemoveCartItem([FromRoute] int cartId, [FromRoute] int cartItemId)
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }
            var result = await cartService.RemoveCartItem(userId.Value, cartId, cartItemId);
            return Ok(result);
        }

        [HttpGet("increment/{cartId:int}/{productId:int}")]
        public async Task<IActionResult> IncrementProduct([FromRoute] int productId, [FromRoute] int cartId)
        {
            var userId = User.GetLoggedInUserId();

            if (!userId.HasValue)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.Increment(userId.Value, cartId, productId);
            return Ok(result);
        }

        [HttpGet("decrement/{cartId:int}/{productId:int}")]
        public async Task<IActionResult> DecrementProduct([FromRoute] int productId, [FromRoute] int cartId)
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }
            var result = await cartService.Decrement(userId.Value, cartId, productId);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListCarts()
        {
            var userId = User.GetLoggedInUserId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            var result = await cartService.ListCartsForUser(userId.Value);
            return Ok(result);
        }
    }
}