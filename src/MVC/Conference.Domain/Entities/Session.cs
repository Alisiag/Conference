using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain.Entities;

public partial class Session : Entity, IValidatableObject
{
    [Required(ErrorMessage = "Поле 'Тема' є обов'язковим!")]
    [Display(Name = "Тема виступу")]
    public string Title { get; set; } = null!;

    [Display(Name = "Опис виступу")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Поле 'Час початку виступу' є обов'язковим!")]
    [Display(Name = "Час початку виступу")]
    public DateTime? StartsAt { get; set; }

    [Required(ErrorMessage = "Поле 'Час завершення виступу' є обов'язковим!")]
    [Display(Name = "Час завершення виступу")]
    public DateTime? EndsAt { get; set; }

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartsAt.HasValue && EndsAt.HasValue)
        {
            if (StartsAt.Value > EndsAt.Value)
            {
                yield return new ValidationResult(
                    "Час завершення виступу не може бути раніше за час початку виступу!",
                    new[] { nameof(EndsAt) }
                );
            }
        }

            if (ConferenceId.HasValue && Conference != null)
            {
                if (StartsAt.HasValue && Conference.StartDate.HasValue && StartsAt.Value < Conference.StartDate.Value)
                {
                    yield return new ValidationResult(
                        "Час початку виступу не може бути раніше за дату відкриття конференції!",
                        new[] { nameof(StartsAt) }
                    );
                }
    
                if (EndsAt.HasValue && Conference.EndDate.HasValue && EndsAt.Value > Conference.EndDate.Value)
                {
                    yield return new ValidationResult(
                        "Час завершення виступу не може бути пізніше за дату завершення конференції!",
                        new[] { nameof(EndsAt) }
                    );
                }
        }
    }

  
}
