using System;
using System.Collections.Generic;

namespace SchoolManagment_Model.Models;

public partial class UserDatum
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPswd { get; set; }
}
