using System;
using System.Collections.Generic;

namespace SchoolManagment_Model.Models;

public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
