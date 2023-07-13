using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Model.CustomeModel
{
    public class CustomeUserModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? UserEmail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? UserMobileno { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? UserPswd { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPswd",ErrorMessage = "Password doesn't match.")]
        public string? ConfirmPswd { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }
        [Required]
        public int? UserRole { get; set; }
    }
}
