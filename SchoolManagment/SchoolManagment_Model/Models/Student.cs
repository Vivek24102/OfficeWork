using System;
using System.Collections.Generic;

namespace SchoolManagment_Model.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string StudentName { get; set; } = null!;

    public int EnrollmentNo { get; set; }

    public string Emailid { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string StAddress { get; set; } = null!;

    public string Teacher { get; set; } = null!;

    public int Country { get; set; }

    public int State { get; set; }

    public int City { get; set; }

    public string Image { get; set; } = null!;

    public virtual City CityNavigation { get; set; } = null!;

    public virtual Country CountryNavigation { get; set; } = null!;

    public virtual State StateNavigation { get; set; } = null!;
}
