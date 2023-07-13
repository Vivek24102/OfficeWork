using Demo_Data.Employee_Repository;
using Demo_Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employee;
      public EmployeeController(IEmployeeRepository employee) 
      {
            _employee = employee;
      }

        
      public async Task<IActionResult> ShowEmployee()
        {
            var data =await _employee.GetEmployee();
            return View(data.ToList());
        }
    }
}
