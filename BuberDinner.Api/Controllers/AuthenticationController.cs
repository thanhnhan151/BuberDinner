using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult LoginAsync(LoginRequest request)
    {
        var authResult = _authenticationService.LoginAsync(
            request.Email,
            request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
            //return Problem(
            //    statusCode: StatusCodes.Status401Unauthorized,
            //    title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("register")]
    public IActionResult RegisterAsync(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.RegisterAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token);
    }
}
