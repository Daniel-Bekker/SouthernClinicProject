using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public DateTime BillAssigned { get; set; }

    public DateTime BillDue { get; set; }

    public string PatientSsn { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Patient PatientSsnNavigation { get; set; } = null!;
}
