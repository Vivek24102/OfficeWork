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
    public class LoginServices : ILogin
    {
        public LoginServices(EmployeeContext employeeContext)
        {
            EmployeeContext = employeeContext;
        }

        public EmployeeContext EmployeeContext { get; }

        public Myuser login(Myuser user)
        {
            

                var data = EmployeeContext.Myusers.Include("UserRoleNavigation").Where(x => x.Useremail == user.Useremail && x.Userpswd == user.Userpswd).FirstOrDefault();
                return data;
            
           
        }

    }
}
