using Employee.Models;
using Employee.Repositry.Repositry;
using Employee_model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISignUp signUp;

        public ILogin _Login { get; }

        public HomeController(ILogger<HomeController> logger,ILogin login,ISignUp signUp)
        {
            _logger = logger;
            _Login = login;
            this.signUp = signUp;
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Myuser user)
        {
            try
            {
                if (_Login.login(user) == 1)
                {
                    
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    ViewBag.Error = "Enter valid ID or Pswd";
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }
        public IActionResult SignUp()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SignUp(Myuser user)
        {
            try
            {
                signUp.SignUp(user);
                return RedirectToAction("login");
            }
            catch (Exception e)
            {
                throw e;
            }
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