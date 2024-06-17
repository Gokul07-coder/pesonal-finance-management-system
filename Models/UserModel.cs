using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pfms.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("User name")]
        public required string Username { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public required string PasswordHash { get; set; }
        [DisplayName("Email address")]
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}