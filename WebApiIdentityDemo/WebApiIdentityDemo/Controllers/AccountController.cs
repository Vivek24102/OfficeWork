using LoginForm_Common.Helper;
using Microsoft.AspNetCore.Mvc;
using WebApiIdentityDemo.Model;
using WebApiIdentityDemo.Services.AccountRepository;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.RegisterModel;
namespace WebApiIdentityDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ISignUpRepository _signUp;

        

        public AccountController(ISignUpRepository signUp)
        {
            this._signUp = signUp;
          
        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(InputModel input)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = ""};
            var data =await _signUp.Register(input);
            if (data != "error")
            {
                response.Data = data;
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [Route("otp")]
        [HttpPost]
        public async Task<IActionResult> otp(string email)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = "" };
            var data = await _signUp.checkotp(email);
               if(data != null)
               {
                return Ok(response);

               }
            else
            {
                return BadRequest(response);
            }

        }
     
    }


    
}
