using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Permission { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
