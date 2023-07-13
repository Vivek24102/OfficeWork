using Dapper;
using LoginForm_Model.Config;
using LoginForm_Model.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForrm_Data.AccountRepository
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<string> Login(LoginModel data)
        {
            var param = new DynamicParameters();
            param.Add("@useremail", data.UserEmail);
            param.Add("@userpswd",data.Password);
            return await QueryFirstOrDefaultAsync<string>("Login", param, commandType: System.Data.CommandType.StoredProcedure);
        }
     }
}
