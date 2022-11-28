using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Employee
{
    public string Ssn { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int RoleId { get; set; }

    public string Lname { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string? Minit { get; set; }

    public DateTime Dob { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
