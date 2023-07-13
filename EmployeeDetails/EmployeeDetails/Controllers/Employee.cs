using Employee_Model.Models;
using Employee_Repositry.Repositry;
using EmployeeDetails.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmployeeDetails.Controllers
{
    [Authorize(Roles = "Admin")]
    [TypeFilter(typeof(JwtFilter))]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class Employee : Controller
    {
        private readonly IEmployee employee;

        public IDepartment Department { get; }

        public Employee(IEmployee employee,IDepartment department)
        {
            this.employee = employee;
            Department = department;
        }
        public IActionResult Index()
        {
             
            return View();
        }

        public IActionResult ShowEmployee() 
        {
            
            return View();
        }
        public  async Task<JsonResult> GetEmployee()
        {
            var model = await employee.details();
            return Json(model);
        }

        public async Task<IActionResult> AddEdit(int id) 
        { 
            if(id == 0)
            {
                ViewBag.DepartmentList = new SelectList(Department.ShowDepartment(), "DeptId", "DeptName");
                return View();
            }
            else
            {
                ViewBag.DepartmentList = new SelectList(Department.ShowDepartment(), "DeptId", "DeptName");
                var data = await employee.GetEployeeById(id);
                return View(data);
            }
        }
        [HttpPost]
        public IActionResult AddEdit(int id,Employee_Model.Models.Employee data)
        {
           if (id == 0)
            {
                employee.AddEmployee(data);
                return RedirectToAction("ShowEmployee", "Employee");            
            }
            else
            {
                employee.UpdateEmployee(data);
                return RedirectToAction("ShowEmployee", "Employee");
            }
        }

        public IActionResult delete(int id)
        {
            employee.delete(id);
            return RedirectToAction("ShowEmployee");
        }

    }
}
