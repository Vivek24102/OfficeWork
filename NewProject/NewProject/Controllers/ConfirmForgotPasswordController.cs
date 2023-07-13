using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class ConfirmForgotPasswordController : Controller
    {
        public ActionResult ConfirmPassword()
        {
            return View();
        }
    }
}
