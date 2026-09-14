using System.ComponentModel.DataAnnotations;

namespace EcoScope.Dtos.UserDTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
