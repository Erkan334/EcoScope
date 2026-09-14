using EcoScope.Dtos.CategoryDTOs;
using EcoScope.Exceptions.CategoryExceptions;
using EcoScope.Models;
using EcoScope.Repositories.CategoryRepositories;

namespace EcoScope.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(int userIdInt)
        {
            var userList = await categoryRepository.GetAllCategoriesAsync();

            return userList;
        }
        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if(category == null)
            {
                throw new CategoryNotFoundException("Category could not be found");
            }

            return category;
        }
        public Task CreateCategoryAsync(CategoryDto dto, int userIdInt)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync()
        {
            throw new NotImplementedException();
        }


        public void RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

    }
}
