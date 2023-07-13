using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface IEmployee 
    {
        Task<List<Employee>> details();

        Task<Employee> GetEployeeById(int id);
        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);
        void delete(int id);



    }
}
