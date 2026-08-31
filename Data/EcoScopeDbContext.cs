using EcoScope.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoScope.Data
{
    public class EcoScopeDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public EcoScopeDbContext(DbContextOptions<EcoScopeDbContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
