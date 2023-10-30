using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtManagement.Models;

public partial class Debit
{
    public int Id { get; set; }

    public int? CreditorId { get; set; }

    public string DebtorName { get; set; } = null!;

    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Invalid phone number")]
    public string? DebtorPhone { get; set; }

    public string? Description { get; set; }

    public virtual User? Creditor { get; set; }

    public virtual ICollection<DebitDetail> DebitDetails { get; set; } = new List<DebitDetail>();

    [NotMapped]
    public decimal RemainingAmount { get; set; }
}
