namespace ExpenseTracker.DTOs
{
    public class AuthResponseDto
    {
        public UserDto User { get; set; } = new();
        public string Token { get; set; } = string.Empty;
    }
}