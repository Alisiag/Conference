using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ConferenceMVC.Domain.Entities;

public partial class Ticket : Entity
{
        [Required(ErrorMessage = "Поле \"Ціна\" є обов'язковим!")]
        [Display(Name = "Ціна")]
    public decimal Price { get; set; }

        [Display(Name = "Знижка")]
    public decimal? Discount { get; set; }

    public int ParticipantId { get; set; }

    public int PeriodId { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Participant Participant { get; set; } = null!;

    public virtual PricingPeriod Period { get; set; } = null!;
}
