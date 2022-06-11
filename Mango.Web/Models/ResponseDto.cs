namespace Mango.Web.Models
{
    //NOTE: We just copy the whole file from Services.Models.DTO
    //Because the response is still in the API
    //And we need to fetch that inside the main project
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
