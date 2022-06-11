using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
