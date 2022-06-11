using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class Product
    {
        //NOTE: Press tab twice / type prop then double tab
        [Key] //NOTE: DataAnnotations that will explicitly define that this is the primary key
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        [Range(1,1000)] //NOTE: This is range attribute

        public double Price { get; set; }

        public string Description { get; set;}

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
