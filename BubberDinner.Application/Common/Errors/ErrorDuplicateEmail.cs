using System.Net;

namespace BubberDinner.Application.Common.Errors;

public record class ErrorDuplicateEmail : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email duplo";
}