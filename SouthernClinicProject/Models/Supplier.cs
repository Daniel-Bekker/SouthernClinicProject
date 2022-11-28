using System;
using System.Collections.Generic;

namespace SouthernClinicProject.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<ItemSupplier> ItemSuppliers { get; } = new List<ItemSupplier>();
}
