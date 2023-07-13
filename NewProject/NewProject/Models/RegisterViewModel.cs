using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NewProject.Models
{
    public class RegisterViewModel
    {


        [Required]
       
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

      
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

     
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

        [ValidateNever]

        public IEnumerable<SelectListItem> RoleList { get; set; }


    }
}
