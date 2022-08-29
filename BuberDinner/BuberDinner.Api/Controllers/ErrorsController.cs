using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Errors.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace   BuberDinner.Api.Controllers;
public class ErrorsController:ControllerBase{
    [Route("/error")]
    public IActionResult Error(){
        Exception? exception=HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode,message)=exception switch{
         IserviceException serviceException=>   ((int)serviceException.StatusCode,serviceException.ErrorsMessage),
            _=>(StatusCodes.Status500InternalServerError,"An unexpected error ocurred."),
        };
        
        return Problem(title:message,statusCode:statusCode);
    }
}