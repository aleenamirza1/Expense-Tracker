using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Helpers
{
    public static class UserHelper
    {
        public static int GetCurrentUserId(ControllerBase controller)
        {
            var userIdClaim = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("User ID not found in token");

            return int.Parse(userIdClaim);
        }
    }
}

