using EcoScope.Data;
using EcoScope.Models;

namespace EcoScope.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(int categoryId);

    }
}
