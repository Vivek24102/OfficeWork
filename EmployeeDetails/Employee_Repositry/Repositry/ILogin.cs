using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface ILogin
    {
        Myuser login(Myuser user);
    }
}
