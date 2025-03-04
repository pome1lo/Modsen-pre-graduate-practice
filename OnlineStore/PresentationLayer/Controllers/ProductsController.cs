using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetAllProductsAsync(cancellationToken));
        }

        
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(productId, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto updatedProduct, CancellationToken cancellationToken)
        {
            await _productService.UpdateProductAsync(productId, updatedProduct, cancellationToken);
            return NoContent(); 
        }

        
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(productId, cancellationToken);
            return NoContent();
        }
    }
}