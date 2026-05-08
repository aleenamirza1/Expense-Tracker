namespace ExpenseTracker.DTOs
{
    public class DashboardDto
    {
        public decimal MonthlySalary { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal RemainingBudget { get; set; }
        public int SavingsRate { get; set; }
        public List<CategorySpendingDto> CategoryWiseSpending { get; set; } = new();
    }

    public class CategorySpendingDto
    {
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}