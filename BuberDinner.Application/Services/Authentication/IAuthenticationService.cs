using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> LoginAsync(string email, string password);
    ErrorOr<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password);
}
