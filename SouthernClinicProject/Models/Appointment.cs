using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string Reason { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int BuildingId { get; set; }

    public int RoomNumber { get; set; }

    public string PatientSsn { get; set; } = null!;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Patient PatientSsnNavigation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<Employee> EmployeeSsns { get; } = new List<Employee>();
}
