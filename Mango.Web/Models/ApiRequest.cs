using static Mango.Web.SD;

namespace Mango.Web.Models
{
    //NOTE: This is the generic implementation of sending an API Request.
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET; //NOTE: ApiType.GET is out default type
        public string Url { get; set; }
        public object Data { get; set; } //NOTE: We don't know what exactly is the type so it will be object, and it will be generic.
        public string AccessToken { get; set; } //NOTE: For authentication purpose
    }
}
