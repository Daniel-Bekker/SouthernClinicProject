using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public int BuildingId { get; set; }

    public string ManagerSsn { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Employee? ManagerSsnNavigation { get; set; }

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
