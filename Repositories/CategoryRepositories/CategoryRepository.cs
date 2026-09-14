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
            return await context.Categories.ToListAsync();
        }


        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        }


        public async Task CreateCategoryAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }



        public void RemoveCategory(Category category)
        {
            context.Categories.Remove(category);
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
