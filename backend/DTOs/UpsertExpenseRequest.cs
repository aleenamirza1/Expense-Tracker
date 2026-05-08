using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DTOs
{
    public class UpsertExpenseRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? ExpenseDate { get; set; }
    }
}