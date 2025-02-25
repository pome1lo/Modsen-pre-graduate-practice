using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public class CategoryService( 
    ICategoryRepository categoryRepository,
    IMapper mapper) : ICategoryService
{
    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto newCategory, CancellationToken cancellationToken = default)
    {
        var categories = await categoryRepository.GetAllAsync();

        if (newCategory == null)
        {
            throw new ArgumentNullException(nameof(newCategory), "Category object cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(newCategory.Name))
        {
            throw new ArgumentException("Category name cannot be empty.", nameof(newCategory));
        }

        if (categories.Any(c => c.Name.Equals(newCategory.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("A category with this name already exists.");
        }

        var category = mapper.Map<Categories>(newCategory);
        await categoryRepository.AddAsync(category);

        return mapper.Map<CategoryDto>(category);
    }

    public async Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var existingCategory = await categoryRepository.GetByIdAsync(categoryId);
        if (existingCategory == null)
        {
            throw new KeyNotFoundException($"Category with ID {categoryId} not found.");
        }

        await categoryRepository.DeleteAsync(categoryId);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await categoryRepository.GetAllAsync();
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var category = await categoryRepository.GetByIdAsync(categoryId);
        if (category is null)
        {
            return null;
        }

        return mapper.Map<CategoryDto>(category);
    }

    public async Task UpdateCategoryAsync(int categoryId, CategoryDto updatedCategory, CancellationToken cancellationToken = default)
    {

        var existingCategory = await categoryRepository.GetByIdAsync(categoryId);

        if (existingCategory is null)
        {
            throw new KeyNotFoundException($"Category with ID {categoryId} not found.");
        }

        existingCategory.Name = updatedCategory.Name;
        await categoryRepository.UpdateAsync(existingCategory);
    }
}