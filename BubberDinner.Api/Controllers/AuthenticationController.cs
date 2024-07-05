using BubberDinner.Application.Services.Authentication.Commands;
using BubberDinner.Application.Services.Authentication.Common;
using BubberDinner.Application.Services.Authentication.Queries;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(
    IAuthenticationCommandService authenticationCommandService,
    IAuthenticationQueryService authenticationQueryService) : ControllerBase
{
    private readonly IAuthenticationCommandService _authenticationCommandService = authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService = authenticationQueryService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr.ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        return registerResult.MatchFirst(
            response => Ok(MapAuthResult(response)),
            firstErr => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstErr.Description)
        );
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

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        return Ok(response);
    }
}