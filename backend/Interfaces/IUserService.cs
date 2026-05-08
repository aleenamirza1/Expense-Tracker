using System.Threading.Tasks;
using ExpenseTracker.DTOs;

namespace ExpenseTracker.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> UpdateSalaryAsync(int userId, UpdateSalaryDto dto);
        Task<UserDto> GetUserProfileAsync(int userId);
    }
}