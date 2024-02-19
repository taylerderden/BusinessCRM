using System;
using System.Collections.Generic;

namespace BusinessCRM.DbModel;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public string Description { get; set; } = null!;

    public long Count { get; set; }

    public long? Supplier { get; set; }

    public uint? Image { get; set; }

    public virtual Supplier? SupplierNavigation { get; set; }
}
