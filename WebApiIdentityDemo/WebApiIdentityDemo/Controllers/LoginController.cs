
using LoginForm_Common.Helper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using WebApiIdentityDemo.Services.AccountRepository;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.LoginModel;
namespace WebApiIdentityDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _login;

        public LoginController(ILoginRepository login)
        {
            this._login = login;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(InputModel input)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = "" };
            var obj = await _login.login(input);
            if (obj == "Invalid login attempt")
            {
                response.Data = "Invalid login attempt";
                return BadRequest(response);
                
            }
            if (obj == "error")
            {
                response.Data = "error";
                return BadRequest(response);
            }
            if (obj == "Success")
            {
                response.Data = "Success";
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }
        }
        
        
      
}
