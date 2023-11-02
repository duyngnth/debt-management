using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DebtManagement.Models;

public partial class User
{
    public int Id { get; set; }

    [RegularExpression(@"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{8,}$", ErrorMessage = "Password must contains at least 8 characters, including digit and letter")]
    public string Password { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public int Type { get; set; }

    public virtual ICollection<Debit> Debits { get; set; } = new List<Debit>();
}
