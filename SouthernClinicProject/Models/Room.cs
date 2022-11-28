using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Room
{
    public int BuildingId { get; set; }

    public int RoomNumber { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
}
