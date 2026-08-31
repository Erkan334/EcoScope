namespace EcoScope.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
