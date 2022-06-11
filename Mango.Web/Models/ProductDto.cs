namespace Mango.Web.Models
{
    public class ProductDto
    {
        //NOTE: We just copy the whole file from Services.Models.DTO
        //Even if this is redundant, it is helpful to isolate things
        //That way we can work w/ 1 piece of code where we are free
        //Because it won't affect anything else in your website
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
