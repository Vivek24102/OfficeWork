using Employee.Repositry.Repositry;
using Employee_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositry.Services
{
    public class SignupService : ISignUp
    {
        private readonly EmployeeContext employeeContext;

        public SignupService(EmployeeContext  employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public int SignUp(Myuser user)
        {
            employeeContext.Myusers.Add(new Myuser
            {
                Id = user.Id,
                Useremail = user.Useremail,
                Usermobileno = user.Usermobileno,
                Userpswd = user.Userpswd,


            });
            employeeContext.SaveChanges();
            return 1;


        }
    }
}
