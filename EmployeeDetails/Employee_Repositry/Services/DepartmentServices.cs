using Employee_Model.Models;
using Employee_Repositry.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Services
{
    public  class DepartmentServices : IDepartment
    {
        public DepartmentServices(EmployeeContext employee)
        {
            Employee = employee;
        }

        public EmployeeContext Employee { get; }

        public List<Department> ShowDepartment()
        {
            var data = Employee.Departments.ToList();
            return data;
        }

        public void Addpdept(Department department)
        {
            Employee.Departments.Add(new Department
            {
                DeptName = department.DeptName
                
        }); 
        Employee.SaveChanges();
        }

        public void Editdept(Department department)
        {
            var data = Employee.Departments.Where(x=> x.DeptId == department.DeptId).FirstOrDefault();
            data.DeptName = department.DeptName;
            Employee.SaveChanges();
        }

        public Department Departmentbyid(int id)
        {
           var data =   Employee.Departments.Where(x=> x.DeptId ==  id).FirstOrDefault();
            return data;
        }
    }
}
