using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceMVC.Domain.Entities;

public partial class Conference : Entity, IValidatableObject
{
    [Required(ErrorMessage ="Поле \"Назва\" є обов'язковим!")]
    [Display(Name = "Назва конференції")]
    public string? Name { get; set; }

    [Display(Name = "Опис конференції")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Поле \"Дата відкриття\" є обов'язковим!")]
    [Display(Name = "Дата відкриття конференції")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Required(ErrorMessage = "Поле \"Дата завершення\" є обов'язковим!")]
    [Display(Name = "Дата завершення конференції")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();

    public virtual ICollection<PricingPeriod> PricingPeriods { get; set; } = new List<PricingPeriod>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate.HasValue && EndDate.HasValue)
        {
            if (StartDate.Value > EndDate.Value)
            {
                yield return new ValidationResult(
                    "Дата завершення не може бути раніше за дату відкриття конференції!",
                    new[] { nameof(EndDate) }
                );
            }
        }
    }
}
