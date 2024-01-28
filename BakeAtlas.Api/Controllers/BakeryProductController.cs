using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryProductController : ControllerBase
    {
        private readonly IBakeryProductService _productService;

        public BakeryProductController(IBakeryProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpPost("Add-Product")]
        public IActionResult AddProduct([FromBody] BakeryProductDTO productDto)
        {
            _productService.AddProduct(productDto);
            return Ok("Product added successfully");
        }

        [HttpGet("Get-All-Products")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("Get-Product-By-Id")]
        public IActionResult GetProductById(string id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound($"Product with Id {id} not found");
            }

            return Ok(product);
        }

        [HttpPut("Update-Product")]
        public IActionResult UpdateProduct(string productId, [FromBody] BakeryProductDTO productDto)
        {
            _productService.UpdateProduct(productId, productDto);
            return Ok("Product updated successfully");
        }

        [HttpDelete("Delete-Product")]
        public IActionResult DeleteProduct(string id)
        {
            _productService.DeleteProduct(id);
            return Ok("Product deleted successfully");
        }
    }
}
