using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DebtManagement.Models;

public partial class DebitDetail
{
    public int Id { get; set; }

    public int? DebitId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "The amount must be greater than 0")]
    public decimal Amount { get; set; }

    public bool IsPaid { get; set; }

    public DateTime Date { get; set; }

    public DateTime? Deadline { get; set; }

    public string? Description { get; set; }

    public virtual Debit? Debit { get; set; }
}
