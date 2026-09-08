using EcoScope.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScope.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200), MinLength(2)]
        public string Title { get; set; } = null!;

        [Range(1, 1000000)]
        public decimal CostAmount { get; set; }

        public BillingFrequency BillingFrequency { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
