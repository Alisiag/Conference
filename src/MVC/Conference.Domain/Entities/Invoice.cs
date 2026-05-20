using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class Invoice : Entity
{
    [Required(ErrorMessage = "Поле \"Загальна сума\" є обов'язковим!")]
    [Display(Name = "Загальна сума")]
    public decimal? TotalAmount { get; set; }

    [Display(Name = "Статус")]
    public InvoiceStatus? Status { get; set; }

    public int? TicketId { get; set; }

    public virtual ContactPerson? ContactPerson { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
