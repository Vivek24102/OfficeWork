using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodemo_Model.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string ? MiddleName { get; set; }

        public string? Lastname { get; set;}

        [DataType(DataType.Date)]
        public DateTime  Dob { get; set; }

        public string? Gender { get; set; }

        public string? mobileno { get; set; }


        public string? EmailAddress { get; set; }

        public string? qulification { get; set; }

        public string? Experiance { get; set; }

        public string? createdBy { get; set;}

        public DateTime? createdDate { get; set;}

        public string ? updatedby { get; set; }
        public DateTime? updatedDate { get; set;}


        public string? deletedby { get; set; }

        public DateTime? deleteddate { get; set; }








    }
}
