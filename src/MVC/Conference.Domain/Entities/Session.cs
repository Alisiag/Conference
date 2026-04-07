using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Session : Entity
{

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? StartsAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
