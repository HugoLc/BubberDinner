using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(
    ISender mediator) : ControllerBase
{
    // private readonly IMediator _mediator = mediator;
    private readonly ISender _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
        return registerResult.MatchFirst(
            response => Ok(MapAuthResult(response)),
            firstErr => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstErr.Description)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);
        if (authResult.IsError)
        {
            return Problem();
        }
        // var response = new AuthenticationResponse(
        //     authResult.User.Id,
        //     authResult.User.FirstName,
        //     authResult.User.LastName,
        //     authResult.User.Email,
        //     authResult.Token);
        // return Ok(response);
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem()
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
}