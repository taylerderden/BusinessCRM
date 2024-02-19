using System;
using System.Collections.Generic;

namespace BusinessCRM.DbModel;

public partial class Client
{
    public long Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
