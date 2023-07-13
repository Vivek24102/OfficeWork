using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Services.JwtAuthentication
{
    public interface IJwtService
    {
        string GenerateToken(string? emailid, string secretKey, int ValidateMin);
    }
}
