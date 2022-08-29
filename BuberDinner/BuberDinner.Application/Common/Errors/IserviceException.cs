using System.Net;
namespace BuberDinner.Application.Common.Errors;

public interface IserviceException{
    public HttpStatusCode StatusCode {get;}

    public string ErrorsMessage {get;}

}