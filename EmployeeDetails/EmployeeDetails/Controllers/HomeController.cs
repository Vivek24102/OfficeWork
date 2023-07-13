using Employee_Model.CustomeModel;
using Employee_Model.Models;
using Employee_Repositry.Repositry;
using EmployeeDetails.Filter;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;

namespace EmployeeDetails.Controllers
{
    public class HomeController : Controller
    {
        public ILogger<HomeController> Logger { get; }

        public ILogin _Login { get; }
        public ISignUp SignUp1 { get; }
        public IJwtAuth JwtAuth { get; }

        public HomeController(ILogger<HomeController> logger, ILogin login, ISignUp signUp,IJwtAuth jwtAuth)
        {
            Logger = logger;
            _Login = login;
            SignUp1 = signUp;
            JwtAuth = jwtAuth;
        }

        [TypeFilter(typeof(JwtFilter))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
           List<Myuser> data= SignUp1.GetMyusers().Where(x => x.Useremail == HttpContext.Session.GetString("umail")).ToList();
            //TempData.Keep("data1");
            return View(data);
        }

        public IActionResult Login()
        {
           

            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Myuser user)
        
        {
            try
            {
                ClaimsIdentity identity = null;
                bool isAuthentic = false;

                var userData = _Login.login(user);
                if (userData != null)
                {
                    //List<Claim> claims = new List<Claim>()
                    //{
                    //    new Claim(ClaimTypes.NameIdentifier, user.Useremail),
                    //    new Claim("OtherProperties", "Example Role")
                    //};

                    //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    //AuthenticationProperties properties = new AuthenticationProperties()
                    //{
                    //    AllowRefresh = true,
                    //    IsPersistent = true
                    //};
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity), properties);
                    //TempData["data1"] = data;

                    string userToken = JwtAuth.GenerateToken(userData.Useremail, "9670FDCB4C17620D9EFECD90BB080852");
                    HttpContext.Session.SetString("userToken", userToken);

                    var data = user.Useremail;
                    HttpContext.Session.SetString("umail", userData.Useremail);
                    HttpContext.Session.SetString("username", userData.UserName);
                    HttpContext.Session.SetString("userrole", userData.UserRoleNavigation.RoleName);
                   
                    identity = new ClaimsIdentity(new[]
                       {
                                new Claim(ClaimTypes.Name, userData.Useremail),
                                 new Claim(ClaimTypes.Role,userData.UserRoleNavigation.RoleName)
                       }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthentic = true;
                       
                    if(isAuthentic)
                    {
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("Index");
                    }


                    return View ();
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
            ViewBag.Rolelist = new SelectList(SignUp1.GetUserroleb(), "Roleid", "RoleName");
            return View();

        }
        [HttpPost]
        public IActionResult SignUp(Myuser user)
        {
            try
            {
                CustomeUserModel data = new CustomeUserModel();
                {
                    data.UserRole = user.UserRole;
                    data.UserName = user.UserName;
                    data.UserEmail = user.Useremail;
                    data.UserPswd = user.Userpswd;
                    data.UserMobileno = user.Usermobileno;
                }

                SignUp1.SignUp(user);
                return RedirectToAction("login");
            }
            catch (Exception e)
            {
                throw e;


            }
        }
        [TypeFilter(typeof(JwtFilter))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Editpassword(int id)
        {


           
            var data = SignUp1.getuserbyid(id);
            ViewBag.pswd = data.Userpswd;
            CustomePaswword pswddata = new CustomePaswword()
            {
                Id = id,
            };

            return View(pswddata);
        }
        [HttpPost]
        [TypeFilter(typeof(JwtFilter))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Editpassword(CustomePaswword data)
        {

            var pswd = SignUp1.getuserbymodel(data);

            if (data.UserPswd == pswd.Userpswd)
            {
                Myuser user = new Myuser()
                {
                    Id = data.Id,
                    Userpswd = data.newPswd

                };

                SignUp1.Editpswd(user);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.erroe = "enter valid pswd";
                return View();
            }
        }
        [TypeFilter(typeof(JwtFilter))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult EditUser(int id)
        {
            var data =  SignUp1.GetMyusers().Where(x=> x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        [TypeFilter(typeof(JwtFilter))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult EditUser(Myuser user)
        {
            SignUp1.Edit(user);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}