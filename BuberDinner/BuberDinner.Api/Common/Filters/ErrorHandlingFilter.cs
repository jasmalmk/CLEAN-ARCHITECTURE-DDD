using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAtribute:ExceptionFilterAttribute{
    public override void OnException(ExceptionContext context)
    {
        var exception=context.Exception;

        var problemDetails=new ProblemDetails{
            Type="https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
            Title="An error occurred while processing your request",
            Status=(int)HttpStatusCode.InternalServerError
        };

        var errorResult=new {problemDetails};

        context.Result=new ObjectResult(errorResult);

        context.ExceptionHandled=true;

    }
}