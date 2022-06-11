using Mango.Web.Models;
using Mango.Web.Services.Iservices;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService //NOTE: Implement Interface for the body of this class.
    {
        //NOTE: We will remove "=> throw new NotImplementedException(); set => throw new NotImplementedException();"
        //And have getter, setter instead
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        //NOTE: We will implement httpClient using dependency injection
        //Below is the implementation
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");

                //NOTE: We have to send an HTTP request message on the client above.
                HttpRequestMessage message = new HttpRequestMessage();

                //NOTE: This is how you configure the request
                //Make sure there is spelling mistake since we've passing a string.
                message.Headers.Add("Accept", "application/json");

                //NOTE: Since we're creating a generic method, the API below is completely populated when this is called.
                message.RequestUri = new Uri(apiRequest.Url);

                //NOTE: If there are any default request headers, we will clear them out.
                client.DefaultRequestHeaders.Clear();

                //NOTE: We have to serialize the data inside the API request
                //Before assigning that value inside our message.content.
                if (apiRequest.Data != null)
                {
                    //NOTE: JsonConvert can be added by installing Newtonsoft.Json (find and install the latest version)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        Encoding.UTF8, "application/json");
                }

                //NOTE: Once we have populated the data, we will get the HTTP response message.
                HttpResponseMessage apiResponse = null;

                //NOTE: We need to write what is the type of the message.
                //And we will check that based on the type of API request.

                //NOTE: We use switch to because sometimes we need to do something else 
                //inside the case than just assigning the method.
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default :
                        message.Method = HttpMethod.Get;
                        break;
                }

                //NOTE: We need to call the API and send the API so that we'll get a response.
                apiResponse = await client.SendAsync(message);

                //NOTE: Once we get the response, we will have to convert/read it as a string
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                //NOTE: Since this is a generic method, we need to deserialize whatever object is defined here.
                //Then it will be converted back.
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception e) 
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);                
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            //NOTE: This is Garbage Collection
            GC.SuppressFinalize(true);
        }
    }
}
