using Mango.Web.Models;
using Mango.Web.Services.Iservices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        //NOTE: We have to retrieve anything from the API that we will be using inside our Mango.Web
        //to do that, we have to use Dependency Injection.
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //NOTE: This is the index that we call from _Layout.cshtml for our Product.
        public async Task<IActionResult> ProductIndex()
        {
            //NOTE: This is an improvement from c# where List<ProductDto> list = new List<ProductDto>; is improved.
            List<ProductDto> list = new();

            //NOTE: ResponseDto is used here because in our API, that is the object that will be returned back
            //However the ResponseDto that we're using here is referenced from the one that we created inside Mango.Web
            //Because with Microservices, you should never share the code.
            var response = await _productService.GetAllProductsAsync<ResponseDto>();

            //NOTE: We have to deserialized our output
            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
