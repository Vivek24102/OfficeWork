using Ad0Demo.Models;
using Adodemo_Model.Model;
using Adodemo_Repositry.Repositry;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ad0Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee employee;

        public HomeController(ILogger<HomeController> logger,IEmployee employee)
        {
            _logger = logger;
            this.employee = employee;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Getemployee()
        {
            return View(employee.GetEmployees());
        }

        public IActionResult AddEditEmployee(int id)
        {
           if(id == 0)
            {
                ViewBag.id = id;
                return View();
            }
            else
            {
                return View(employee.GetEmployeebyid(id));
            }
        }
        [HttpPost]
        public IActionResult AddEditEmployee(int id,Employee emp)
        {
            if (id == 0)
            {
                employee.AddEmployee(emp);
                return RedirectToAction("Getemployee");
            }
            else
            {
                employee.EditEmployee(emp);
                return RedirectToAction("Getemployee");
            }
        }
        public IActionResult delete(int id)
        {
            employee.delete(id);
            return RedirectToAction("Getemployee");
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