namespace Mango.Services.ProductAPI.Models.Dto
{
    //NOTE: When working with APIs, we receive requests and response,
    //so this class is created.
    public class ResponseDto
    {
        //NOTE: whether request is successful or not
        public bool IsSuccess { get; set; } = true;
        //NOTE: We are not sure what will be the type
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
