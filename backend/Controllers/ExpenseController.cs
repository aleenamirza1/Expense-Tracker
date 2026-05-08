using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ExpenseTracker.DTOs;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Helpers;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                var userId = UserHelper.GetCurrentUserId(this);
                var expenses = await _expenseService.GetUserExpensesAsync(userId);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense(int id)
        {
            try
            {
                var userId = UserHelper.GetCurrentUserId(this);
                var expense = await _expenseService.GetExpenseByIdAsync(id, userId);

                if (expense == null)
                    return NotFound(new { error = "Expense not found" });

                return Ok(expense);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> CreateOrUpdateExpense([FromBody] UpsertExpenseRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Title))
                    return BadRequest(new { error = "Title is required" });

                if (request.Amount <= 0)
                    return BadRequest(new { error = "Amount must be greater than 0" });

                if (string.IsNullOrEmpty(request.Category))
                    return BadRequest(new { error = "Category is required" });

                var userId = UserHelper.GetCurrentUserId(this);
                var expense = await _expenseService.CreateOrUpdateExpenseAsync(userId, request);

                string message = request.Id == null || request.Id == 0
                    ? "Expense created successfully"
                    : "Expense updated successfully";

                return Ok(new { message, expense });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                var userId = UserHelper.GetCurrentUserId(this);
                var deleted = await _expenseService.DeleteExpenseAsync(id, userId);

                if (!deleted)
                    return NotFound(new { error = "Expense not found" });

                return Ok(new { message = "Expense deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}