namespace Mango.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        //NOTE: Copy all the properties of Product Class but remove the annotations
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
