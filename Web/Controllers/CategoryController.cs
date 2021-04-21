namespace SuplementShop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public CategoryController(ICategoryService categoryService,
                                  IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await categoryService.ListAllCategories();
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsForCategory(string name)
        {
            var result = await productService.GetProductsForCategory(name);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var result = await categoryService.AddCategory(category);
            return Ok(result);
        }
    }
}