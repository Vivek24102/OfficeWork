using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Model.JwtModel
{
    public class UserTokenModel
    {
        public string? emailid { get; set; }
        public DateTime TokenValidTo { get; set; }

    }
}
