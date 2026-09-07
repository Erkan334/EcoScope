using System.ComponentModel.DataAnnotations;

namespace EcoScope.Dtos.UserDTOs
{
    public class UpdateUserNameDto
    {
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
    }
}
