using LoginForm_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Data.ForgotPasswordRepository
{
    public interface IForgotPasswordRepository
    {
        Task<int> GetOtp(int otp,string Email );

        Task<string> checkOtp(CheckOtpModel data);

        Task<int> changepaswd(LoginModel data);
    }
}
