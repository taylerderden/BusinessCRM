using System;
using System.Collections.Generic;

namespace BusinessCRM.DbModel;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long Role { get; set; }

    public long Employee { get; set; }

    public string? Salt { get; set; }

    public virtual Employee EmployeeNavigation { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;
}
