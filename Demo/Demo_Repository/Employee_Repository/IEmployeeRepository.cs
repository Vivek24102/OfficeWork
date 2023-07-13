using Demo_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Data.Employee_Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetEmployee();

        Task<int> AddEditEmployee(EmployeeModel user);
    }
}
