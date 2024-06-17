using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfms.Models
{
    public class Income
    {
        [Key]
        public required int IncomeId { get; set; }
        public required int UserId { get; set; }
        public required int CategoryId { get; set; }
        public required decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
