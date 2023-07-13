using Employee.Repositry.Repositry;
using Employee_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositry.Services
{
    public class LoginServices : ILogin
    {
     

        public LoginServices(EmployeeContext employeeContext)
        {
            EmployeeContext = employeeContext;
        }

        public EmployeeContext EmployeeContext { get; }

        public int login(Myuser user)
        {
            if(EmployeeContext.Myusers.Any(x=> x.Useremail == user.Useremail && x.Userpswd == user.Userpswd))
            {
            
            return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
