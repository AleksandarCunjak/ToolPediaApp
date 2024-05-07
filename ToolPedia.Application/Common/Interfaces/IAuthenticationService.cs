namespace ToolPedia.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Guid> RegisterUser(string userName, string password);
        Task<Guid> ValidateCredentials(string userName, string password);
    }
}
