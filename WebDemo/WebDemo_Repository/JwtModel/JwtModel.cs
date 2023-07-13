using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo_Model.JwtModel
{
    public  class JwtModel
    {
        public string? SecretKey { get; set; }
        public int ValidateMin { get; set; }
    }
}
