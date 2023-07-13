using Employee_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositry.Repositry
{
    public interface ISignUp
    {
        int SignUp(Myuser user);
    }
}
