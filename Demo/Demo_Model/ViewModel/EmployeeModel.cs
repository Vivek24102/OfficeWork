﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Model.ViewModel
{
    public  class EmployeeModel
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int dDepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }


    }

}
