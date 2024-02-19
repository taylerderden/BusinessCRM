using System;
using System.Collections.Generic;

namespace BusinessCRM.DbModel;

public partial class Supplier
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public long? Inn { get; set; }

    public long? Kpp { get; set; }

    public string? BankAccount { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
