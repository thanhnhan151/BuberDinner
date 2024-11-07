using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> LoginAsync(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmailAsync(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (!user.Password.Equals(password))
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmailAsync(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) & Persist user to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.AddAsync(user);

        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
