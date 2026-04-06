using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public int ParticipantId { get; set; }

    public int PeriodId { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Participant Participant { get; set; } = null!;

    public virtual PricingPeriod Period { get; set; } = null!;
}
