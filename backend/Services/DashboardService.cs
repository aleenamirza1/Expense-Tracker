using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.DTOs;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardDataAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;

            var monthlyExpenses = await _context.Expenses
                .Where(e => e.UserId == userId &&
                           e.ExpenseDate.Month == currentMonth &&
                           e.ExpenseDate.Year == currentYear)
                .ToListAsync();

            var totalSpent = monthlyExpenses.Sum(e => e.Amount);
            var remainingBudget = user.Salary - totalSpent;

            int savingsRate = user.Salary > 0
                ? (int)((remainingBudget / user.Salary) * 100)
                : 0;

            var categorySpending = monthlyExpenses
                .GroupBy(e => e.Category)
                .Select(g => new CategorySpendingDto
                {
                    Category = g.Key,
                    Amount = g.Sum(e => e.Amount)
                })
                .ToList();

            return new DashboardDto
            {
                MonthlySalary = user.Salary,
                TotalSpent = totalSpent,
                RemainingBudget = remainingBudget,
                SavingsRate = savingsRate,  
                CategoryWiseSpending = categorySpending
            };
        }
    }
}