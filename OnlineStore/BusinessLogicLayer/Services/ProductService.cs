using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto newProduct, CancellationToken cancellationToken = default)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct), "Product object cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(newProduct.Name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(newProduct));
            }

            var products = await productRepository.GetAllAsync(cancellationToken);
            if (products.Any(p => p.Name.Equals(newProduct.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A product with this name already exists.");
            }

            var product = mapper.Map<Products>(newProduct);
            await productRepository.AddAsync(product, cancellationToken);

            return mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken = default)
        {
            var existingProduct = await productRepository.GetByIdAsync(productId, cancellationToken);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            await productRepository.DeleteAsync(productId, cancellationToken);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            var products = await productRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(productId, cancellationToken);
            if (product is null)
            {
                return null;
            }

            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            var products = await productRepository.GetProductsByCategoryIdAsync(categoryId, cancellationToken); // Измените на правильное имя метода
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task UpdateProductAsync(int productId, ProductDto updatedProduct, CancellationToken cancellationToken = default)
        {
            var existingProduct = await productRepository.GetByIdAsync(productId, cancellationToken);
            if (existingProduct is null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.CategoryId = updatedProduct.CategoryId;

            await productRepository.UpdateAsync(existingProduct, cancellationToken);
        }
    }
}