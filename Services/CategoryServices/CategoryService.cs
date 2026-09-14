using EcoScope.Dtos.CategoryDTOs;
using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Exceptions.CategoryExceptions;
using EcoScope.Models;
using EcoScope.Repositories.CategoryRepositories;
using EcoScope.Result;

namespace EcoScope.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await categoryRepository.GetAllCategoriesAsync();
            
            return categories.Select(category => new CategoryDto
            {
                Title = category.Title,

            }).ToList();
        }
        public async Task<DataResult<CategoryDto>> GetCategoryByIdAsync(int categoryId)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if(category == null)
            {
                return new DataResult<CategoryDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Category could not be found"
                };
            }

            var categoryDto = new CategoryDto
            {
                Title = category.Title
            };

            return new DataResult<CategoryDto>
            {
                IsSuccess = true,
                Data = categoryDto,
                Message = null
            };

        }
        

    }
}
