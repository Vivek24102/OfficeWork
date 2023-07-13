using System;
using System.Collections.Generic;

namespace SchoolManagment_Model.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Country { get; set; }

    public int State { get; set; }

    public int City { get; set; }

    public string Subject { get; set; } = null!;

    public virtual City CityNavigation { get; set; } = null!;

    public virtual Country CountryNavigation { get; set; } = null!;

    public virtual State StateNavigation { get; set; } = null!;
}
