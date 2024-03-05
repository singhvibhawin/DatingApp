using System.Security.Claims;

namespace API.Interfaces
{
    public static class ClaimsPrincipalExtension
    {
        public static string GeUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}