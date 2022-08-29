using System.Net;

namespace BuberDinner.Application.Common.Errors.Exceptions;

public class DuplicateEmailExceptions : Exception, IserviceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorsMessage =>"Email Already exists.";
}