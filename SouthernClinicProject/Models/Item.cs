using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public int? Dosage { get; set; }

    public bool IsMedication { get; set; }

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<ItemSupplier> ItemSuppliers { get; } = new List<ItemSupplier>();

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
