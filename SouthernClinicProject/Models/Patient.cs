using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Patient
{
    public string Ssn { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string? Minit { get; set; }

    public DateTime Dob { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
