using System.ComponentModel.DataAnnotations;

namespace EcoScope.Dtos.CategoryDTOs
{
    public class CategoryDto
    {
        [Required]
        [MaxLength(100), MinLength(1)]
        public string Title { get; set; } = string.Empty;
    }
}
