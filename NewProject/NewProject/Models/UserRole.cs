using Microsoft.AspNetCore.Identity;

namespace NewProject.Models
{
    public class UserRole:IdentityUser
    {

        public string FirstName { get; set;}

        public string LastName { get; set;} 

    }
}
