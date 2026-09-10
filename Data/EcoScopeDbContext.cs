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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<int>>().HasData(

                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "dc9b2704-13c0-4423-9959-aa5dc3f5a57a"
                });

            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Title = "Rent",
                },

                new Category
                {
                    Id = 2,
                    Title = "Groceries",
                },

                new Category
                {
                    Id = 3,
                    Title = "Transport",
                },

                new Category
                {
                    Id = 4,
                    Title = "Clothing",
                },

                new Category
                {
                    Id = 5,
                    Title = "Saving",
                },

                new Category
                {
                    Id = 6,
                    Title = "Miscellaneous",
                },

                new Category
                {
                    Id = 7,
                    Title = "Loan",
                },

                new Category
                {
                    Id = 8,
                    Title = "Subscription",
                }
            );
        }

    }
}
