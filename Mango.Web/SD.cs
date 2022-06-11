namespace Mango.Web
{
    //NOTE: Static because in that way we don't have to create an object.
    public static class SD
    {
        public static string ProductAPIBase { get; set; }
        
        //NOTE: This is API type whenever we make API calls
        //We use our Enum to make sure that we do not make any spelling mistake.
        public enum ApiType 
        { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
