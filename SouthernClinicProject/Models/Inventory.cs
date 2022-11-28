using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Inventory
{
    public int BuildingId { get; set; }

    public int RoomNumber { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
