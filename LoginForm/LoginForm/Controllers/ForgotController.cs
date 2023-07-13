using LoginForm_Common.Helper;
using LoginForm_Data.EmailRepository;
using LoginForm_Data.ForgotPasswordRepository;
using LoginForm_Data.RandomRepository;
using LoginForm_Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotController : ControllerBase
    {
        private readonly IEmailRepository _email;
        private readonly IRandomRepository _random;
        private readonly IForgotPasswordRepository _forgot;

        public ForgotController(IEmailRepository email,IRandomRepository random,IForgotPasswordRepository forgot)
        {
            this._email = email;
            this._random = random;
            this._forgot = forgot;
        }
        [Route("Forgotpassword")]
        [HttpPost]
       public ActionResult Forgotpassword(string Email)
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            var data = _random.randomNumber();
            var data1 = data.ToString();
            _email.sendEmail(Email, data1, "your otp");
            var obj= _forgot.GetOtp(data,Email);
            if(obj != null)
            {
            response.Success = true;
                response.Message = "success";
                
            return Ok(response);    
            }
            else
            {
                return BadRequest(response);
            }
        }
        [Route("Checkotp")]
        [HttpPost]
        public async Task<ActionResult> Checkotp(CheckOtpModel obj) 
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            var result= await _forgot.checkOtp(obj);
            if(result != null)
            {
                response.Success = true;
                   response.Message = "success";   
                return Ok(response);

            }
            else { return BadRequest(response); }
        }

        [Route("changepassword")]
        [HttpPost]
        public async Task<ActionResult> changepassword(LoginModel data)
        {
            ApiResponse<string> res = new ApiResponse<string>() ;
            var result = await _forgot.changepaswd(data);
            if(result != null)
            {
                res.Success = true;
                res.Message = "success";
                return Ok(res);

            }
            else return BadRequest(res);
        }
     }
}
