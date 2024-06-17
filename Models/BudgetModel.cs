using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfms.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        //set userid as unique
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

    }

}

// CREATE TABLE Budgets (
//     BudgetId SERIAL PRIMARY KEY,
//     UserId INT NOT NULL,
//     CategoryId INT NOT NULL,
//     Amount DECIMAL(10, 2) NOT NULL,
//     Month INT NOT NULL,
//     Year INT NOT NULL,
//     FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE,
//     FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE,
//     UNIQUE (UserId, CategoryId, Month, Year)
// );
