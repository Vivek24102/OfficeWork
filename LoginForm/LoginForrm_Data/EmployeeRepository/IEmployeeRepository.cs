using LoginForm_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForrm_Data.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> EmployeeDetails();
        Task<IEnumerable<Employee>> paginator(PaginationViewModel data);

        Task<int> AddeditEmployee(Employee data);

        Task<int> DeleteEmployee(int id);

        Task<Employee> EmployeeByID(int id);

    }
}
