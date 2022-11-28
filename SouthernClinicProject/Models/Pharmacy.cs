using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Pharmacy
{
    public int PharmacyId { get; set; }

    public string Name { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
