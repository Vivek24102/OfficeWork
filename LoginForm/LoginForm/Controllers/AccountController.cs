using LoginForm_Common.Helper;
using LoginForm_Model.JwtModel;
using LoginForm_Model.ViewModel;
using LoginForm_Services.JwtAuthentication;
using LoginForrm_Data.AccountRepository;
using LoginForrm_Data.SignInRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Cms;

namespace LoginForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IRegisterRepository user;
        private readonly ILoginRepository _login;

        public IJwtService Jwt { get; }

      JwtModel authenticationModel;

        public AccountController(IRegisterRepository user,ILoginRepository login,IJwtService jwt, IOptions<JwtModel> option) {
            this.user = user;
            _login = login;
            Jwt = jwt;
            authenticationModel = option.Value;
        }

        [HttpPost("AddUser")]
        [AllowAnonymous]
        public   async void SignUp([FromBody] UserModel data)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = "" };
            string result  = await user.SignUp(data);
            if (result == null)
            {
                response.Data = "Succesfully added";
                response.Success = true;
                response.Message = "OK";
                
            }
            else {
                response.Data = "Error";
        
            }
         

        }

        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult>   login([FromBody] LoginModel data)
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            var  result = await _login.Login(data);
            if(result == null)
            {
                response.Data= "Invalid details";
                response.Success = false;
                return BadRequest(response);
            }
            else
            {
                string JwtToken = Jwt.GenerateToken(data.UserEmail, authenticationModel.SecretKey, authenticationModel.ValidateMin);
                response.Data = JwtToken;
           
                response.Success= true;
                response.Message = "OK";
                return Ok(response);
            }
           
        }


        
    }
}
