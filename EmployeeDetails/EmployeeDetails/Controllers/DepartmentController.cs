using Employee_Model.Models;
using Employee_Repositry.Repositry;
using EmployeeDetails.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;

namespace EmployeeDetails.Controllers
{
    [Authorize(Roles = "Admin")]
    [TypeFilter(typeof(JwtFilter))]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DepartmentController : Controller
    {
        public DepartmentController(IDepartment dep)
        {
            Dep = dep;
        }

        public IDepartment Dep { get; }

        public IActionResult ShowDepartment()
        {
            return View(Dep.ShowDepartment());
        }

        public IActionResult AddEditDepartment(int id)
        {
            if(id == 0)
            {
                return View();
            }
            else
            {
                var data = Dep.Departmentbyid(id);
                 return View(data);
            }
        }

        [HttpPost]
        public IActionResult AddEditDepartment(Department department)
        {
            if (department.DeptId == 0)
            {
                Dep.Addpdept(department);
                return RedirectToAction("ShowDepartment");
            }
            else
            {
               Dep.Editdept(department);
                return RedirectToAction("ShowDepartment");
            }
        }
    }
}
