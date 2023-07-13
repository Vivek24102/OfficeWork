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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginForrm_Data.EmployeeRepository
{
    public class EmployeeRepositorycs : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepositorycs(IOptions<DataConfig> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<IEnumerable<Employee>> EmployeeDetails()
        {
            
            return await QueryAsync<Employee>("ShowEmployee", null, commandType: System.Data.CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Employee>> paginator(PaginationViewModel data)
        {
            var param = new DynamicParameters();
            param.Add("@PageSize", data.PageSize);
            param.Add("@PageNumber", data.PageNumber);
         
            return await QueryAsync<Employee>("Sp_EmployeeList", param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> AddeditEmployee(Employee data)
        {
            var param = new DynamicParameters();
            param.Add("@id", data.Id);
            param.Add("@EmployeeName", data.EmployeeName);
            param.Add("@EmployeeSurname", data.EmployeeSurname);
            param.Add("@EmployeeDOB", data.EmployeeDOB);
            param.Add("@EmployeeEmail", data.EmployeeEmail);
            param.Add("@EmployeeAddress", data.EmployeeAddress);
            return await ExecuteAsync<int>("AddEditEmployee", param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int>  DeleteEmployee(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id",id);
            return await ExecuteAsync<int>("deleteEmp", param, commandType: System.Data.CommandType.StoredProcedure);


        }

        public async Task<Employee> EmployeeByID(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);
            return await QueryFirstOrDefaultAsync<Employee>("EmployeeByid", param, commandType: System.Data.CommandType.StoredProcedure);

        }
    }
}
