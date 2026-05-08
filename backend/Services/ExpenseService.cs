using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.DTOs;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _context;

        public ExpenseService(ApplicationDbContext context)

        {
            _context = context;
        }

        public async Task<List<ExpenseDto>> GetUserExpensesAsync(int userId)
        {
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.ExpenseDate)
                .ToListAsync();

            return expenses.Select(e => new ExpenseDto
            {
                Id = e.Id,
                Title = e.Title,
                Amount = e.Amount,
                Category = e.Category,
                Description = e.Description,
                ExpenseDate = e.ExpenseDate,
                UserId = e.UserId,
                CreatedOn = e.CreatedOn
            }).ToList();
        }

        public async Task<ExpenseDto?> GetExpenseByIdAsync(int id, int userId)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

            if (expense == null)
                return null;

            return new ExpenseDto
            {
                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                UserId = expense.UserId,
                CreatedOn = expense.CreatedOn
            };
        }

        public async Task<ExpenseDto> CreateOrUpdateExpenseAsync(int userId, UpsertExpenseRequest request)
        {
            string[] validCategories = { "Food", "Transport", "Shopping", "Entertainment", "Bills" };
            if (!validCategories.Contains(request.Category))
                throw new Exception("Invalid category. Must be: Food, Transport, Shopping, Entertainment, or Bills");

            Expense expense;
            bool isCreate = request.Id == null || request.Id == 0;

            if (isCreate)
            {
                expense = new Expense
                {
                    Title = request.Title,
                    Amount = request.Amount,
                    Category = request.Category,
                    Description = request.Description,
                    ExpenseDate = request.ExpenseDate ?? DateTime.UtcNow,
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow
                };

                await _context.Expenses.AddAsync(expense);
            }
            else
            {
                expense = await _context.Expenses
                    .FirstOrDefaultAsync(e => e.Id == request.Id && e.UserId == userId);

                if (expense == null)
                    throw new Exception($"Expense with ID {request.Id} not found");

                expense.Title = request.Title;
                expense.Amount = request.Amount;
                expense.Category = request.Category;

                if (request.Description != null)
                    expense.Description = request.Description;

                if (request.ExpenseDate.HasValue)
                    expense.ExpenseDate = request.ExpenseDate.Value;

                expense.UpdatedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            return new ExpenseDto
            {
                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                UserId = expense.UserId,
                CreatedOn = expense.CreatedOn
            };
        }

        public async Task<bool> DeleteExpenseAsync(int id, int userId)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}