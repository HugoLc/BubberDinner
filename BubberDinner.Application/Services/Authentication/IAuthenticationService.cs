using ErrorOr;
using FluentResults;

namespace BubberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
