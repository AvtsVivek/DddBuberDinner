using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occured while processing your request.",
            //Instance = context.HttpContext.Request.Path,
            Status = StatusCodes.Status500InternalServerError,
            //Detail = exception.Message
        };

        var errorResult = new { error = "An error occured while processing your request."};

        // context.Result = new ObjectResult(new { error = "An error occured while processing your request." })
        // {
        //     StatusCode = 500
        // };

        context.Result = new ObjectResult(problemDetails);
        

        context.ExceptionHandled = true;

        // if (context.Exception is NotFoundException)
        // {
        //     // handle 404
        //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        // }
        // else if (context.Exception is BadRequestException)
        // {
        //     // handle 400
        //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        // }
        // else
        // {
        //     // handle 500
        //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        // }
    }
}