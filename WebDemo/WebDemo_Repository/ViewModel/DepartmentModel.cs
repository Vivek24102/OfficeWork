using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo_Model.ViewModel
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
