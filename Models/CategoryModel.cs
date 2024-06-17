using System.ComponentModel.DataAnnotations;

namespace pfms.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public CategoryType CategoryType { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();

    }
    public enum CategoryType
    {
        Income,
        Expense
    }
}