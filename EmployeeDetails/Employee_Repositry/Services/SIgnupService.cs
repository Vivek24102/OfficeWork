using Employee_Model.CustomeModel;
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
    public class SIgnupService : ISignUp
    {
        public readonly EmployeeContext employeeContext;

        public SIgnupService(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public int SignUp(Myuser user)
        {
            employeeContext.Myusers.Add(new Myuser
            {
                Id = user.Id,
                UserRole = user.UserRole,
                UserName = user.UserName,
                Useremail = user.Useremail,
                Usermobileno = user.Usermobileno,
                Userpswd = user.Userpswd,


            });
            employeeContext.SaveChanges();
            return 1;


        }

        public List<Myuser> GetMyusers()
        {
           var data= employeeContext.Myusers.Include("UserRoleNavigation").ToList();
            return data;
        }

        public void Edit(Myuser user)
        {
            var data =  employeeContext.Myusers.Where(x=> user.Id == x.Id).FirstOrDefault();
            data.Useremail = user.Useremail;
            data.Usermobileno = user.Usermobileno;
            //data.UserName = user.UserName;
            employeeContext.SaveChanges();

           
        }
        public void Editpswd(Myuser user)
        {
            var data = employeeContext.Myusers.Where(x => user.Id == x.Id).FirstOrDefault();
           data.Userpswd = user.Userpswd;
            employeeContext.SaveChanges();


        }
        public Myuser getuserbyid(int id)
        {
            var data = employeeContext.Myusers.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return data;
        }
        public Myuser getuserbymodel(CustomePaswword customePaswword)
        {
            var data = employeeContext.Myusers.Where(x => x.Id.Equals(customePaswword.Id)).FirstOrDefault();
            return data;
        }
        public List<Myuser> getuserbyrolel()
        {
            List<Myuser> data = employeeContext.Myusers.Where(x => x.UserRole.Equals(2)).ToList();
            return data;
        }

        public List<Userrole> GetUserroleb()
        {
            List<Userrole> data = employeeContext.Userroles.ToList();
            return data;
        }


    }
   
}
