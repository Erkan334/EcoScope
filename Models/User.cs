using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcoScope.Models
{
    public class User : IdentityUser<int>
    {
        [MinLength(2), MaxLength(50)]
        public string? Name { get; set; }

        public List<Expense> Expenses { get; set; }

    }
}
