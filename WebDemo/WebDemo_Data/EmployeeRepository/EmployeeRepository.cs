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

namespace WebDemo_Data.EmployeeRepository
{
    public class EmployeeRepository : BaseRepository ,IEmployeeRepository
    {
        public EmployeeRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<string> AddEmployee(EmployeeModel user)
        {

            try
            {
                if (user.Id == 0)
                {

                    var param = new DynamicParameters();
                    param.Add("@id", user.Id);
                    param.Add("@Name", user.Name);
                    param.Add("@Email", user.Email);
                    param.Add("@ContactNo", user.ContactNo);
                    param.Add("@Address", user.Address);
                    param.Add("@departmentid", user.dDepartmentId);
                    return await QueryFirstOrDefaultAsync<string>("Sp_AddEditEmployee", param, commandType: System.Data.CommandType.StoredProcedure);
                }
                else
                {
                    var param = new DynamicParameters();
                    param.Add("@id", user.Id);
                    param.Add("@Name", user.Name);
                    param.Add("@Email", user.Email);
                    param.Add("@ContactNo", user.ContactNo);
                    param.Add("@Address", user.Address);
                    param.Add("@departmentid", user.dDepartmentId);
                    return await QueryFirstOrDefaultAsync<string>("Sp_AddEditEmployee", param, commandType: System.Data.CommandType.StoredProcedure);

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            var data = await QueryAsync<EmployeeModel>("Sp_ShowEmoloyee", commandType: System.Data.CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
