using System;
using System.Collections.Generic;

namespace DebtManagement.Models;

public partial class DebitDetail
{
    public int Id { get; set; }

    public int? DebitId { get; set; }

    public decimal Amount { get; set; }

    public bool IsPaid { get; set; }

    public DateTime Date { get; set; }

    public DateTime? Deadline { get; set; }

    public string? Description { get; set; }

    public virtual Debit? Debit { get; set; }
}
