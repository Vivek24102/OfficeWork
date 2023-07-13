using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Model.ViewModel
{
    public  class LoginModel
    {
        [Required]
        public String EmailId { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
