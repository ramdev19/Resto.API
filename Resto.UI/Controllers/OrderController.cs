using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resto.UI.Helper;
using System.Text.Json.Serialization;


namespace Resto.UI.Controllers
{
    public class OrderController : Controller
    {
       // OrderAPI _api = new OrderAPI();
        private readonly ILogger<HomeController> _logger;

        public OrderController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      
        //public async Task <IActionResult> Index()
        //{
        //    List<Transaction> trans = new List<Transaction>();
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync("api/transactions");

        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //        trans = JsonConvert.DeserializeObject<List<Transaction>>(result);
        //    }
        //    return View(trans);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
