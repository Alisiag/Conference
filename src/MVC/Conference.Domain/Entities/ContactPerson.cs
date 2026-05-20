using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ConferenceMVC.Domain.Entities;

public partial class ContactPerson : Entity
{
    [Required(ErrorMessage ="Поле \"Ім'я\" є обов'язковим!")]
    [Display(Name = "Ім'я")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Поле \"Прізвище\" є обов'язковим!")]
    [Display(Name = "Прізвище")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Поле \"Електронна пошта\" є обов'язковим!")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    [Display(Name = "Електронна пошта")]
    public string? Email { get; set; }

    public int InvoiceId { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
