using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo_Model.ViewModel;

namespace WebDemo_Data.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<string> AddEmployee(EmployeeModel user);

        Task<List<EmployeeModel>> GetEmployee();
    }
}
