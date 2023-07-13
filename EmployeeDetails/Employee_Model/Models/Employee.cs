using System;
using System.Collections.Generic;

namespace Employee_Model.Models;

public partial class Employee
{
    public int Emplooyeid { get; set; }

    public string? EmployeeName { get; set; }

    public string? Emailid { get; set; }

    public string? ContactNo { get; set; }

    public string? EmpAddress { get; set; }

    public int? Departmentid { get; set; }

    public virtual Department? Department { get; set; }
}
