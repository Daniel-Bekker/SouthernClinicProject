using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public string PatientSsn { get; set; } = null!;

    public int PharmacyId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public string EmployeeSsn { get; set; } = null!;

    public DateTime PrescribedOn { get; set; }

    public int Refills { get; set; }

    public int Frequency { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Patient PatientSsnNavigation { get; set; } = null!;

    public virtual Pharmacy Pharmacy { get; set; } = null!;
}
