using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Model.CustomeModel
{
    public class CustomePaswword
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? UserPswd { get; set; }
        [Required]
        [DataType(DataType.Password)]
       
        public string? newPswd { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("newPswd", ErrorMessage = "Password doesn't match.")]
        public string? ConfirmPswd { get; set; }



    }
}
