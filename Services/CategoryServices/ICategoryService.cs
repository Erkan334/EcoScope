using EcoScope.Dtos.CategoryDTOs;
using EcoScope.Models;
using EcoScope.Result;

namespace EcoScope.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();

        Task<DataResult<CategoryDto>> GetCategoryByIdAsync(int categoryId);

        
    }
}
