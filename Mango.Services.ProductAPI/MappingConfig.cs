using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        //NOTE: A method that will return the mapping configuration of autoMapper
        //Public Static = so that we can call it in our startup class file
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //NOTE: We can also use .ReverseMap(); to reduce two lines into one config.CreateMap
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            //NOTE: Telling automapper, we want to convert ProductDto to Product and vice versa
            //automapper will automatically map the properties, as long as they have the same name
            return mappingConfig;
        }
    }
}
