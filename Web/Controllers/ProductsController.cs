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
    [Route("api/product")]
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
            var products = await productService.GetProducts();
            return this.ToResult(products);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await productService.GetProduct(id);
            return this.ToResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var role = User.GetUserRole();
            if (role != Role.Admin)
            {
                return Unauthorized();
            }

            var response = await productService.CreateProduct(request);

            return this.ToResult(response);
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

            var response = await productService.UpdateProduct(id, request);

            return this.ToResult(response);
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

            var response = await productService.DeleteProduct(id);

            return this.ToResult(response);
        }

        [AllowAnonymous]
        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var response = await productService.SearchProducts(searchTerm);
            return this.ToResult(response);
        }

        [AllowAnonymous]
        [HttpGet("manufacturer/{manufacturer}")]
        public async Task<IActionResult> GetAllByManufacturer(string mannufacturer)
        {
            var response = await productService.GetAllByMannufacturer(mannufacturer);
            return this.ToResult(response);
        }
    }
}
