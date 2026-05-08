using ExpenseTracker.DTOs;

namespace ExpenseTracker.Interfaces
{
    public interface IExpenseService
    {
        Task<List<ExpenseDto>> GetUserExpensesAsync(int userId);
        Task<ExpenseDto?> GetExpenseByIdAsync(int id, int userId);
        Task<ExpenseDto> CreateOrUpdateExpenseAsync(int userId, UpsertExpenseRequest request);
        Task<bool> DeleteExpenseAsync(int id, int userId);
    }
}