using System;
using System.Collections.Generic;

namespace Employee_Model.Models;

public partial class Myuser
{
    public int Id { get; set; }

    public int? UserRole { get; set; }

    public string? UserName { get; set; }

    public string? Useremail { get; set; }

    public string? Usermobileno { get; set; }

    public string? Userpswd { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual Userrole? UserRoleNavigation { get; set; }
}
