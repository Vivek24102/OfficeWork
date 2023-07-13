using Dapper;
using LoginForm_Model.Config;
using LoginForm_Model.ViewModel;
using LoginForrm_Data.SignInRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForrm_Data.RegisterRepository
{
    public class RegisterRepository : BaseRepository, IRegisterRepository 
    {
        public RegisterRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<string> SignUp(UserModel user)
        {
            var param = new DynamicParameters();
            param.Add("@userfirstname", user.userFirstName);
            param.Add("@UserlastNAme",user.userLastName);
            param.Add("@userMobileNo", user.userMobileNo);
            param.Add("@useremail", user.userEmail);
            param.Add("@gender", user.gender);
            param.Add("@userpswd", user.userPswd);
            return await QueryFirstOrDefaultAsync<string>("InertUser",param, commandType: CommandType.StoredProcedure);
        }
    }
}
