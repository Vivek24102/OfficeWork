using System;
using System.Collections.Generic;

namespace Employee_Model.Models;

public partial class Task
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public string? TaskName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? TaskDescription { get; set; }

    public virtual ICollection<Tasklog> Tasklogs { get; set; } = new List<Tasklog>();

    public virtual Myuser? User { get; set; }
}
