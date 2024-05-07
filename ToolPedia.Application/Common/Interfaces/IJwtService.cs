using System.Security.Claims;

namespace ToolPedia.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string userName);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
