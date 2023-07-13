using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebDemo_Common.Helper;
using WebDemo_Data.LoginRepository;
using WebDemo_Model.JwtModel;
using WebDemo_Model.ViewModel;
using WebDemo_Services.JwtAuthentication;

namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        JwtModel authenticationModel;

        public LoginController(ILoginRepository _login, IJwtService _jwtService, IOptions<JwtModel> option)
        {
            Login1 = _login;
            JwtService = _jwtService;
            authenticationModel = option.Value;
        }

        public ILoginRepository Login1 { get; }
        public IJwtService JwtService { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiPostResponse<string>> Login([FromForm] LoginModel user)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = "" };
            var data = await Login1.Login(user);
            if (data == null)
            {
                response.Data = "Invalid Details";
                response.Success = true;
                response.Message = "OK";

            }
            else
            {
                string JwtToken = JwtService.GenerateToken(data.UserEmail, authenticationModel.SecretKey, authenticationModel.ValidateMin);
                response.Data = JwtToken;
                response.Success = true;
                response.Message = "OK";
            }
            return response;
        }
     
      
    }
}
