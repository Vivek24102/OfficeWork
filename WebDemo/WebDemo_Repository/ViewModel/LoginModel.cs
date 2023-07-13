using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo_Model.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter EmailId")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid Email Address.")]
        public string UserEmail { get; set;}

        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPswd { get; set;}
    }
}
