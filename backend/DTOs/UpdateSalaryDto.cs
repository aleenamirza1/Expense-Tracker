using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DTOs
{
    public class UpdateSalaryDto
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }
    }
}