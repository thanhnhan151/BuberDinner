namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult LoginAsync(string email, string password);
    AuthenticationResult RegisterAsync(string firstName, string lastName, string email, string password);
}
