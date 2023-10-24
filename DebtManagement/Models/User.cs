using System;
using System.Collections.Generic;

namespace DebtManagement.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Debit> Debits { get; set; } = new List<Debit>();
}
