using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(
    ICategoryService categoryService
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories(CancellationToken cancellationToken = default)
    {
        var categories = await categoryService.GetAllCategoriesAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id, CancellationToken cancellationToken = default)
    {
        var category = await categoryService.GetCategoryByIdAsync(id, cancellationToken);
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto newCategory, CancellationToken cancellationToken = default)
    {
        var createdCategory = await categoryService.CreateCategoryAsync(newCategory, cancellationToken);
        return Ok(createdCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto updatedCategory, CancellationToken cancellationToken = default)
    {
        await categoryService.UpdateCategoryAsync(id, updatedCategory, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken = default)
    {
        await categoryService.DeleteCategoryAsync(id, cancellationToken);
        return Ok();
    }
}