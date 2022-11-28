using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public string Description { get; set; } = null!;

    public decimal MinSalary { get; set; }

    public decimal MaxSalary { get; set; }

    public bool CanPerscribe { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
