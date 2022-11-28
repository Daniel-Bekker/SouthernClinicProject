using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Building
{
    public int BuildingId { get; set; }

    public string Name { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public int MaxOccupancy { get; set; }

    public string ManagerSsn { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
