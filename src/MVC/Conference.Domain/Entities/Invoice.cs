using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? Status { get; set; }

    public int? TicketId { get; set; }

    public virtual ContactPerson? ContactPerson { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
