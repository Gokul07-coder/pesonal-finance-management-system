using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfms.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public required int UserId { get; set; }
        public required int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
