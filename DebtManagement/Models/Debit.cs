using System;
using System.Collections.Generic;

namespace DebtManagement.Models;

public partial class Debit
{
    public int Id { get; set; }

    public int? CreditorId { get; set; }

    public string DebtorName { get; set; } = null!;

    public string? DebtorPhone { get; set; }

    public string? Description { get; set; }

    public virtual User? Creditor { get; set; }

    public virtual ICollection<DebitDetail> DebitDetails { get; set; } = new List<DebitDetail>();
}
