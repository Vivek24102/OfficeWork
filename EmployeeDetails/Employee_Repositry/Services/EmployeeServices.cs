using Employee_Model.Models;
using Employee_Repositry.Repositry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Services
{
    public class EmployeeServices : IEmployee
    {
        public EmployeeServices(EmployeeContext employeeContext)
        {
            EmployeeContext = employeeContext;
        }

        public EmployeeContext EmployeeContext { get; }
        public async Task<List<Employee>> details()
        {
          var data = await EmployeeContext.Employees.Include("Department").Select(_ => new Employee
          {
              ContactNo = _.ContactNo,
              EmpAddress = _.EmpAddress,
              Departmentid = _.Departmentid,
              Emailid = _.Emailid,
              Emplooyeid = _.Emplooyeid,
              EmployeeName = _.EmployeeName,
              Department = _.Department,
              
          }).ToListAsync();
            return data;
        }

        public void AddEmployee(Employee employee)
        {
           
            {
                EmployeeContext.Employees.Add(new Employee
                {
                    EmployeeName = employee.EmployeeName,
                    EmpAddress = employee.EmpAddress,
                    Departmentid = employee.Departmentid,
                    Emailid = employee.Emailid,
                    ContactNo = employee.ContactNo,

                });
                EmployeeContext.SaveChanges();
               
            }
            
        }
        
        public void UpdateEmployee(Employee employee)
        {
            var data =  EmployeeContext.Employees.Where(x=> x.Emplooyeid == employee.Emplooyeid).FirstOrDefault();
            data.EmployeeName = employee.EmployeeName;
            data.EmpAddress = employee.EmpAddress;
            data.Departmentid= employee.Departmentid;
            data.Emailid= employee.Emailid;
            data.ContactNo  = employee.ContactNo;
            EmployeeContext.SaveChanges();

        }

        
        public void delete(int id)
        {
            var data = EmployeeContext.Employees.Where(x=>x.Emplooyeid == id).FirstOrDefault(); 
            EmployeeContext.Employees.Remove(data);
            EmployeeContext.SaveChanges();        }

        public async Task<Employee> GetEployeeById(int id)
        {
            var model = await EmployeeContext.Employees.Where(x => x.Emplooyeid == id).Select(_ => new Employee
            {
                ContactNo = _.ContactNo,
                EmpAddress = _.EmpAddress,
                Departmentid = _.Departmentid,
                Emailid = _.Emailid,
                Emplooyeid = _.Emplooyeid,
                EmployeeName = _.EmployeeName
            }).FirstOrDefaultAsync();
            return model;
        }
    }
}
