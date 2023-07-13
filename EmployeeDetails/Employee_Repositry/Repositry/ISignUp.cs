using Employee_Model.CustomeModel;
using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface ISignUp
    {
        int SignUp(Myuser user);

        List<Myuser> GetMyusers();

        void Edit(Myuser user);

        void Editpswd(Myuser user);

        Myuser getuserbyid(int id);

        Myuser getuserbymodel(CustomePaswword data);

        List<Userrole> GetUserroleb();

        List<Myuser> getuserbyrolel();
    }
}
