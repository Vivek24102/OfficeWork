using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employee_Model.Models;

namespace Employee_Repositry.Repositry
{
    public interface ITask
    {
        List<Employee_Model.Models.Task> GetTasks();

        List<Employee_Model.Models.Task> GetTasksbyname(string name);
        void Edittask(Employee_Model.Models.Task task);

        void Addtask(Employee_Model.Models.Task task);

        Employee_Model.Models.Task Gettaskbyid(int id);
    }
}
