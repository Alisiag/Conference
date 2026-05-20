using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class Participant : Entity
{
    [Required(ErrorMessage = "Поле \"Ім'я\" є обов'язковим!")]
    [Display(Name = "Ім'я")]
    public string? Name { get; set; }

    [Display(Name = "Прізвище")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Поле \"Електронна пошта\" є обов'язковим!")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    [Display(Name = "Електронна пошта")] 
    public string? Email { get; set; }

    [Required(ErrorMessage = "Поле \"Пароль\" є обов'язковим!")]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Конференція")]
    public int ConferenceId { get; set; }

    [Display(Name = "Компанія")]
    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Ticket? Ticket { get; set; }
}
