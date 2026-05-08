using ExpenseTracker.DTOs;
using System.Threading.Tasks;

namespace ExpenseTracker.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardDataAsync(int userId);
    }
}