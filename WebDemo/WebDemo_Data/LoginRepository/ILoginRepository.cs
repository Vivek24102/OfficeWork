using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo_Model.ViewModel;

namespace WebDemo_Data.LoginRepository
{
    public interface ILoginRepository
    {
        Task<UserModel> Login(LoginModel user);
    }
}
