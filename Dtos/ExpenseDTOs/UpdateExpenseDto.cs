using EcoScope.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScope.Dtos.ExpenseDTOs
{
    public class UpdateExpenseDto
    {
        [Required]
        [MaxLength(200), MinLength(2)]
        public string Title { get; set; } = null!;

        [Range(1, 1000000)]
        public decimal CostAmount { get; set; }

        public BillingFrequency BillingFrequency { get; set; }

        public int CategoryId { get; set; }
    }
}
