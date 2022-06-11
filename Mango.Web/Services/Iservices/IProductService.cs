using Mango.Web.Models;

namespace Mango.Web.Services.Iservices
{
    //NOTE: Inside, we will perform all the CRUD operations

    //NOTE: We have inherited IBaseService after implementing our method SendAsync
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto); //NOTE: Because we copy the productdto class from services, we can now add this.
        Task<T> UpdateProductAsync<T>(ProductDto productDto); //NOTE: Because we copy the productdto class from services, we can now add this.
        Task<T> DeleteProductAsync<T>(int id);

    }
}
