using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(
    ISender mediator,
    IMapper mapper
    ) : ControllerBase
{
    // private readonly IMediator _mediator = mediator;
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        // var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
        return registerResult.MatchFirst(
            response => Ok(_mapper.Map<AuthenticationResponse>(response)),
            firstErr => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstErr.Description)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // var query = new LoginQuery(request.Email, request.Password);
        var query = _mapper.Map<LoginQuery>(request);
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
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem()
        );
    }
}