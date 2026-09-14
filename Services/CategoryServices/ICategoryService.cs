using EcoScope.Dtos.CategoryDTOs;
using EcoScope.Models;

namespace EcoScope.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync(int userIdInt);

        Task<Category?> GetCategoryByIdAsync(int categoryId);

        Task CreateCategoryAsync(CategoryDto dto, int userIdInt);

        Task UpdateCategoryAsync();


        void RemoveCategory(int categoryId);

        Task SaveAsync();
    }
}
