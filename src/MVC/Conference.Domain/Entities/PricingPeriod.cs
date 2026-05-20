using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class PricingPeriod : Entity, IValidatableObject
{
    [Required(ErrorMessage = "Поле \"Назва\" є обов'язковим!")]
    [Display(Name = "Назва періоду")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Поле \"Ціна квитка\" є обов'язковим!")]
    [Display(Name = "Ціна квитка")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Поле 'Час початку періоду' є обов'язковим!")]
    [Display(Name = "Час початку періоду")]
    public DateTime? StartDate { get; set; }

    [Required(ErrorMessage = "Поле 'Час завершення періоду' є обов'язковим!")]
    [Display(Name = "Час завершення періоду")]
    public DateTime? EndDate { get; set; }

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate.HasValue && EndDate.HasValue)
        {
            if (StartDate.Value > EndDate.Value)
            {
                yield return new ValidationResult(
                    "Час завершення періоду не може бути раніше за час початку періоду!",
                    new[] { nameof(EndDate) }
                );
            }
        }
    }
}
