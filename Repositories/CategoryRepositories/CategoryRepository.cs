using EcoScope.Data;
using EcoScope.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScope.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly EcoScopeDbContext context;

        public CategoryRepository(EcoScopeDbContext _context)
        {
            context = _context;
        }


        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await context.Categories.AsNoTracking()
                                           .ToListAsync();
        }


        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await context.Categories.AsNoTracking()
                                           .FirstOrDefaultAsync(c => c.Id == categoryId);

        }

    }
}
