using Dapper;
using Demo_Model.Config;
using Demo_Model.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Data.Login_Repository
{
    public class LoginRepository : BaseRepositry, ILoginRepository
    {
        public LoginRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<UserModel> LoginUser(LoginModel user)
        {

            try
            {
                var param = new DynamicParameters();
                param.Add("@Email", user.EmailId);
                param.Add("@pswd", user.Password);
                return await QueryFirstOrDefaultAsync<UserModel>("Sp_Login", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
