using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        //NOTE: Task because we want asynchronous
        Task<IEnumerable<ProductDto>> GetProducts();
        //NOTE: Return type is ProductDto
        Task<ProductDto> GetProductById(int productId);
        //NOTE: Create or update a product, we receive a productDto model
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
