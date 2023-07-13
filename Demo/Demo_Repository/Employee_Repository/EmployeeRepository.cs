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

namespace Demo_Data.Employee_Repository  
{
    public class EmployeeRepository : BaseRepositry, IEmployeeRepository
    {
        public EmployeeRepository(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        
        public async Task<List<EmployeeModel>> GetEmployee()
        {

            try
            {
              var  Data = await QueryAsync<EmployeeModel>("Sp_ShowEmoloyee", commandType: System.Data.CommandType.StoredProcedure);
                return Data.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddEditEmployee(EmployeeModel user)
        {

            try
            {
                if(user.Id == 0)
                {

                var param = new DynamicParameters();
                    param.Add("@id", null);
                    param.Add("@Name", user.Name);
                    param.Add("@Email",user.Email);
                    param.Add("@ContactNo", user.ContactNo);
                    param.Add("@Address", user.Address);
                    param.Add("@departmentid", user.dDepartmentId);
                    return await ExecuteAsync<int>("Sp_AddEditEmployee", param, commandType: System.Data.CommandType.StoredProcedure);
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
                    return await ExecuteAsync<int>("Sp_AddEditEmployee", param, commandType: System.Data.CommandType.StoredProcedure);

                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }

            
    }
}
