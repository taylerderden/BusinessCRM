using System;
using System.Collections.Generic;

namespace BusinessCRM;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public string Description { get; set; } = null!;

    public long Count { get; set; }

    public long? Supplier { get; set; }

    public long? CategoryId { get; set; }

    public string? Image { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? SupplierNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
