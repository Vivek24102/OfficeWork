using LoginForm_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForrm_Data.SignInRepository
{
    public interface IRegisterRepository
    {
        Task<string> SignUp(UserModel user);
    }
}
