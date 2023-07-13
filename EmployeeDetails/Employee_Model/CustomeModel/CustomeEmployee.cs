using Employee_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Model.CustomeModel
{
    internal class CustomeEmployee
    {
        
        public int Emplooyeid { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? EmployeeName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Emailid { get; set; }
        [Required]
        public string? ContactNo { get; set; }
        [Required]
        public string? EmpAddress { get; set; }
        [Required]
        public int? Departmentid { get; set; }
        [Required]
        public virtual Department? Department { get; set; }
        
    }
}
