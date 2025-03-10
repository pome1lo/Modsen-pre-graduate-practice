using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetAllProductsAsync(cancellationToken));
        }

        
        [HttpGet("{productId}")]
        [Authorize]
        public async Task<ActionResult<ProductDto>> GetProductById(int productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(productId, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser(ProductDto createProduct, CancellationToken cancellationToken)
        {
            return Ok(await _productService.CreateProductAsync(createProduct, cancellationToken));
        }
        
        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto updatedProduct, CancellationToken cancellationToken)
        {
            await _productService.UpdateProductAsync(productId, updatedProduct, cancellationToken);
            return NoContent(); 
        }

        
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(productId, cancellationToken);
            return NoContent();
        }
    }
}