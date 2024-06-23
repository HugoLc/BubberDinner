using System.Net;
using FluentResults;

namespace BubberDinner.Application.Common.Errors;

public class ErrorDuplicateEmail : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}