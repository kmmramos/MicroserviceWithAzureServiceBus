using Mango.Web.Models;
using Mango.Web.Services.Iservices;

namespace Mango.Web.Services
{
    //NOTE: Add IProductService and implement interface
    public class ProductService : BaseService, IProductService
    {
        //NOTE: Our ProductService is expecting httpClient of baseService IHttpClient
        //so that we need to pass it here using Dependency Injection
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            //NOTE: We need to pass the ApiRequest since SendAsync expect it.
            return await this.SendAsync<T>(new ApiRequest()
            {
                //NOTE: SD.ApiType has the enum values
                ApiType = SD.ApiType.POST,
                Data = productDto,
                //NOTE: SD.ProductAPIBase is the localhost url
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
            //NOTE: The code is simple because we have created a SendAsync method
            //that has all the complexities of creating and calling the API.
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                //NOTE: Data = productDto is not expected in DeleteProductAsync, just the int id.
                //So we just need to pass it in the url.
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                //NOTE: There are no parameters expected for GetAllProductsAsync.
                Url = SD.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }
    }
}
