using System;
using System.Collections.Generic;

namespace Employee_Model.Models;

public partial class Tasklog
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public string? TaskLog1 { get; set; }

    public DateTime? Logdate { get; set; }

    public virtual Task? Task { get; set; }
}
