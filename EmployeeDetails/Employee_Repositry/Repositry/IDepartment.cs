using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface IDepartment
    {
        List<Department> ShowDepartment();

        Department Departmentbyid (int id);
        void Addpdept(Department department);

        void Editdept(Department department);
    }
}
