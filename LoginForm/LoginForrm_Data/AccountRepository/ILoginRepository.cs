using LoginForm_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForrm_Data.AccountRepository
{
    public interface ILoginRepository
    {
        Task<string> Login(LoginModel data);
    }
}
