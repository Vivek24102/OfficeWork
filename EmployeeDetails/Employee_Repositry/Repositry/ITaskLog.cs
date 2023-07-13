using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface ITaskLog
    {
      List<Tasklog> GetLogs();

        Tasklog GetLogsbyid(int id);
        void Addtasklog(Tasklog data);

        void EditTaskLog(Tasklog data);

        List<Tasklog> GetLogsbytaskid(int id);
    }
}
