using Employee_Model.Models;
using Employee_Repositry.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Services
{
    public class TaskServices : ITask
    {
        public TaskServices(EmployeeContext employeeContext)
        {
            EmployeeContext = employeeContext;
        }

        public EmployeeContext EmployeeContext { get; }

        public List<Employee_Model.Models.Task> GetTasks()
        {
            List<Employee_Model.Models.Task> data = EmployeeContext.Tasks.Include("User").ToList();
            return data;
        }

        public void Addtask(Employee_Model.Models.Task  task)
        {
            EmployeeContext.Tasks.Add(new Employee_Model.Models.Task()
            {
                Userid = task.Userid,
                TaskName = task.TaskName,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                TaskDescription = task.TaskDescription,

            });
            EmployeeContext.SaveChanges();
        }

        public void Edittask(Employee_Model.Models.Task task)
        {
            var data = EmployeeContext.Tasks.Where(x => x.Id == task.Id).FirstOrDefault();
            data.Userid = task.Userid;
            data.TaskName = task.TaskName;
            data.StartDate = task.StartDate;
            data.EndDate = task.EndDate;
            data.TaskDescription = task.TaskDescription;
            EmployeeContext.SaveChanges();
        }

        public Employee_Model.Models.Task Gettaskbyid(int id)
        { 
           var data = EmployeeContext.Tasks.Where(x=>x.Id == id).FirstOrDefault();
            return data;
        }

        public List<Employee_Model.Models.Task> GetTasksbyname(string name)
        {
            
            List<Employee_Model.Models.Task> data  = EmployeeContext.Tasks.Include("User").Where(x=> x.User.UserName == name).ToList();
            return data;
        }
    }
}
