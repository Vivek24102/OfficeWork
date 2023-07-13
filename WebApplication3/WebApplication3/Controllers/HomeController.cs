using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.DataBase;
using WebApplication3.DataBase.DbModel;
using WebApplication3.Model;
  


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DummyDbContext dummyDbContext;

        public HomeController(ILogger<HomeController> logger,DummyDbContext dummyDbContext)
        {
            _logger = logger;
            this.dummyDbContext = dummyDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Country country)
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}