using System;
using System.Collections.Generic;

namespace Employee_Model.Models;

public partial class Userrole
{
    public int Roleid { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Myuser> Myusers { get; set; } = new List<Myuser>();
}
