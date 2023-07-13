using Adodemo_Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodemo_Repositry.Repositry
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();

        void AddEmployee(Employee emp);

        void EditEmployee(Employee emp);

        Employee GetEmployeebyid(int id);

        void delete(int id);
    }
}
