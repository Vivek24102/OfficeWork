using Demo_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Data.Login_Repository
{
    public interface ILoginRepository
    {
        Task<UserModel> LoginUser(LoginModel user);
    }
}
