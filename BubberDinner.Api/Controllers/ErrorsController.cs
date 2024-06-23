using BubberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

//Para erros usando oneof
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "email exists"),
            _ => (StatusCodes.Status500InternalServerError, "internal error")
        };


        return Problem(title: message, statusCode: statusCode);
    }
}