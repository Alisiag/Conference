using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class Partner : Entity
{
    [Required(ErrorMessage = "Поле 'Назва' є обов'язковим!")]
    [Display(Name = "Назва компанії")]
    public string? Name { get; set; }

    [Display(Name = "Рівень партнерства")]
    public PartnershipLevel? PartnershipLevel { get; set; }

    public int ConferenceId { get; set; }

    public virtual Conference Conference { get; set; } = null!;
}
