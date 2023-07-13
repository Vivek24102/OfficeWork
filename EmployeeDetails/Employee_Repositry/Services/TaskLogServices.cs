using Employee_Model.Models;
using Employee_Repositry.Repositry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Services
{
   
    public class TaskLogServices : ITaskLog
    {
        
        
        public List<Tasklog> GetLogs()
        {
            using(EmployeeContext db =  new EmployeeContext())
            {
                List<Tasklog> data = db.Tasklogs.Include("Task").ToList();
                return data;
                 
            }

           
        }
        public Tasklog GetLogsbyid(int id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                Tasklog data = db.Tasklogs.Where(x=> x.Id == id).FirstOrDefault();
                return data;

            }


        }
        public List<Tasklog> GetLogsbytaskid(int id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                List<Tasklog> data = db.Tasklogs.Where(x => x.TaskId == id).ToList();
                return data;

            }


        }

        public void Addtasklog(Tasklog data)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Tasklogs.Add(new Tasklog
                {
                    TaskId = data.TaskId,
                    TaskLog1   = data.TaskLog1,
                    Logdate = data.Logdate,
                });
                db.SaveChanges();
            }
        }

        public void EditTaskLog(Tasklog data)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var task = db.Tasklogs.Where(x => x.Id == data.Id).FirstOrDefault();
                task.TaskId =  data.TaskId;
                task.TaskLog1 = data.TaskLog1;
                task.Logdate
                    = data.Logdate;
                db.SaveChanges();   
            }
        }
    }
}
