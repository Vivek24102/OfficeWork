using Dapper;
using LoginForm_Model.Config;
using LoginForm_Model.ViewModel;
using LoginForrm_Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Data.ForgotPasswordRepository
{
    public class ForgotPasswordRepository :BaseRepository, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<int> GetOtp(int otp,string Email)
        {
            var param = new DynamicParameters();
            param.Add("@otp", otp);
            param.Add("@email", Email);
            return await ExecuteAsync<int>("fgotp", param, commandType: System.Data.CommandType.StoredProcedure);

        }

        public async Task<string> checkOtp(CheckOtpModel data)
        {
            var param = new DynamicParameters();
            param.Add("@otp", data.otp);
            param.Add("@email", data.email);
            return await QueryFirstOrDefaultAsync<string>("validateotp", param, commandType: System.Data.CommandType.StoredProcedure);
        }
        public async Task<int> changepaswd(LoginModel data)
        {
            var param = new DynamicParameters();
            param.Add("@email", data.UserEmail);
            param.Add("@password" ,data.Password);
            return await ExecuteAsync<int>("changepassword", param, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
    
}
