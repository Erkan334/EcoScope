using Microsoft.AspNetCore.Identity;

namespace EcoScope.Models
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }

        public List<Expense> Expenses { get; set; }

    }
}
