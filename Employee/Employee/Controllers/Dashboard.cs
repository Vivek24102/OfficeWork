using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
 
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }


}
