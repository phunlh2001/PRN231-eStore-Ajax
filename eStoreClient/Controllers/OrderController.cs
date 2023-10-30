using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eStoreClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient client;
        private string api;

        public OrderController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            api = "https://localhost:44336/api/";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("cancel")]
        public async Task Cancel(int id)
        {
            await client.DeleteAsync(api + $"order/{id}");
        }
    }
}
