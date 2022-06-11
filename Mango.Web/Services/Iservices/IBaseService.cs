using Mango.Web.Models;

namespace Mango.Web.Services.Iservices
{
    //NOTE: We need to implement the generic method to send the service.
    public interface IBaseService : IDisposable
    {
        //NOTE: ResponseDto because that is what we will receive.
        ResponseDto responseModel { get; set; }

        //NOTE: We need to create a generic method to send the request,
        //the return type would be generic.

        //NOTE: ApiRequest because this is the model we created for sending/storing everything related to an API request.
        //And so we will pass that as a parameter.
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
