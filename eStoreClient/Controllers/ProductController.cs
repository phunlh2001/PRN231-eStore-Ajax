using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
