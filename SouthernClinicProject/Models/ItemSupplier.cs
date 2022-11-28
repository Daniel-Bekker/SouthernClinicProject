using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class ItemSupplier
{
    public int SupplierId { get; set; }

    public int ItemId { get; set; }

    public int? Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
