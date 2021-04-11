namespace SuplementShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using SuplementShop.Application.Requests;
    using SuplementShop.Web.Extensions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("product")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts()
        {
            ICollection<Product> products = await productService.GetProducts();
            return Ok(products);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            Product product = await productService.GetProduct(id);
            return product != null ? Ok(product) : NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var role = User.GetUserRole();
            if (role != Role.Admin)
            {
                return Unauthorized();
            }

            await productService.CreateProduct(request);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest request)
        {
            var role = User.GetUserRole();
            if (role != Role.Admin)
            {
                return Unauthorized();
            }

            await productService.UpdateProduct(id, request);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var role = User.GetUserRole();
            if (role != Role.Admin)
            {
                return Unauthorized();
            }

            await productService.DeleteProduct(id);

            return Ok();
        }
    }
}
