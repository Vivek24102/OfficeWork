using Demo_Data.Login_Repository;
using Demo_Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        private ILoginRepository _login;
        public LoginController(ILoginRepository login)
        { 
            _login = login;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoginUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel model)
        {
            UserModel user = new UserModel();
            user = await _login.LoginUser(model);
            if (user != null)
            {
                return RedirectToAction ("Index", "Home");

            }
            else
            {
                TempData["Error"] = "Enter valid Id or Pswd";
                return View();
            }

        }
        
    }
}
