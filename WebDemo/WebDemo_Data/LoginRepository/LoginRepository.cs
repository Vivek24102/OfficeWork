using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo_Model.Config;
using WebDemo_Model.ViewModel;

namespace WebDemo_Data.LoginRepository
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<UserModel> Login(LoginModel user)
        {
            var param = new DynamicParameters();
            param.Add("@Email", user.UserEmail);
            param.Add("@pswd", user.UserPswd);
            return await QueryFirstOrDefaultAsync<UserModel>("Sp_Login", param, commandType: System.Data.CommandType.StoredProcedure);

        }
    }
}
