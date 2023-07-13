using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Repositry.Repositry
{
    public interface IJwtAuth
    {
        string GenerateToken(string emailId, string SecretKey);
    }
}
