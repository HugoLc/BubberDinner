using BubberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace BubberDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}
