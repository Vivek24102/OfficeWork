using Employee_Model.Models;
using EmployeeDetails.Filter;
using Microsoft.AspNetCore.Mvc;
using Employee_Repositry.Repositry;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeDetails.Controllers
{
    [TypeFilter(typeof(JwtFilter))]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Authorize(Roles = "Devloper")]
    public class TaskLogController : Controller
    {
        public TaskLogController(ITaskLog tasklog_, ITask contask)
        {
            Tasklog_ = tasklog_;
            Contask = contask;
        }

        public ITaskLog Tasklog_ { get; }
        public ITask Contask { get; }

        public IActionResult showtasklog(int id)
        {
            
            return View(Tasklog_.GetLogsbytaskid(id));
        }

        public IActionResult AddEdittasklog(int id)
        {
            if(id == 0)
            {
                string name = (HttpContext.Session.GetString("username"));

                ViewBag.TaskList = new SelectList(Contask.GetTasksbyname(name), "Id", "TaskName");
                return View();
            }
            else
            {
                string name = (HttpContext.Session.GetString("username"));

                ViewBag.TaskList = new SelectList(Contask.GetTasksbyname(name), "Id", "TaskName");
                var data = Tasklog_.GetLogsbyid(id);
                return View(data);
            }
           
        }
        [HttpPost]
        public IActionResult AddEdittasklog(int id,Tasklog tasklog)
        {
            if(id == 0)
            {
                Tasklog_.Addtasklog(tasklog);
                return RedirectToAction("showtasklog");
            }
            else
            {
                Tasklog_.EditTaskLog(tasklog);
                return RedirectToAction("showtasklog");
            }
        }
    }
}
