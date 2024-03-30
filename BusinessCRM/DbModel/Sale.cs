using System;
using System.Collections.Generic;

namespace BusinessCRM;

public partial class Sale
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public decimal Sum { get; set; }

    public long EmployeeId { get; set; }

    public long ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
