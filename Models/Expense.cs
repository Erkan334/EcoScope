using EcoScope.Enums;

namespace EcoScope.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal CostAmount { get; set; }
        public BillingFrequency BillingFrequency { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
