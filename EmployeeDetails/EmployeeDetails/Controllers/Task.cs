using Employee_Model.Models;
using Employee_Repositry.Repositry;
using EmployeeDetails.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace EmployeeDetails.Controllers
{


    [TypeFilter(typeof(JwtFilter))]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class Task : Controller
    {
     
        public Task(ITask contask,ISignUp signUp)
        {
            Taskdata = contask;
            SignUp = signUp;
        }

        public ITask Taskdata { get; }
        public ISignUp SignUp { get; }

        public IActionResult ShowTask(Myuser user)
        {
            string userrole = (HttpContext.Session.GetString("userrole"));

            if (userrole == "Admin")
            {
                List<Employee_Model.Models.Task> task = Taskdata.GetTasks();
                return View(task);
            }
            else
            {
                string name = (HttpContext.Session.GetString("username"));
                List<Employee_Model.Models.Task> data = Taskdata.GetTasksbyname(name);
                return View(data);
            }
        }
        
       
        [Authorize(Roles = "Admin")]
        public IActionResult AddEditTask(int id)
        {
            if(id ==  0)
            {
                ViewBag.UserList = new SelectList(SignUp.getuserbyrolel(), "Id", "UserName");
                return View();
            }
            else
            {
                ViewBag.UserList = new SelectList(SignUp.getuserbyrolel(), "Id", "UserName");
                var data = Taskdata.Gettaskbyid(id);
                return View(data);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEditTask(int id, Employee_Model.Models.Task task)
        {
            if (id == 0)
            {
                Taskdata.Addtask(task);
                return RedirectToAction("ShowTask");
            }
            else
            {
                Taskdata.Edittask(task);
                return RedirectToAction("ShowTask");
            }
        }
    }
}
