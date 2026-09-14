using EcoScope.Dtos.CategoryDTOs;
using EcoScope.Models;
using EcoScope.Result;
using EcoScope.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet]
        [Route("category/{categoryId:int}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByIdAsync(int categoryId)
        {
            var result = await categoryService.GetCategoryByIdAsync(categoryId);

            if(!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result.Data);


        }
    }
}
