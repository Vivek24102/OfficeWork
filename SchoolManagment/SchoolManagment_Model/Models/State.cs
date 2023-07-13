using System;
using System.Collections.Generic;

namespace SchoolManagment_Model.Models;

public partial class State
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
