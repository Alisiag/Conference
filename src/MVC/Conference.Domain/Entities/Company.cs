using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class Company : Entity
{
    [Required(ErrorMessage = "Поле \"Назва\" є обов'язковим!")]
    [Display(Name = "Назва компанії")]
    public string? Name { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
