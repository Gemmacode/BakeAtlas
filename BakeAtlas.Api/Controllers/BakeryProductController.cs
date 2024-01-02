using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryProductController : ControllerBase
    {
        private readonly IBakeryProductService _productService;

        public BakeryProductController(IBakeryProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get-Products")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("Get-Product-By-Id")]
        public IActionResult GetProduct(string id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost("Add-Product")]
        public IActionResult AddProduct(BakeryProduct product)
        {
            _productService.AddProduct(product);
            return Ok(product);
        }
    }
}
