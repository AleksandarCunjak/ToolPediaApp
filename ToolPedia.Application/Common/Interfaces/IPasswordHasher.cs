namespace ToolPedia.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string password, string hashedPassword, string salt);
    }
}
