using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Conference : Entity
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();

    public virtual ICollection<PricingPeriod> PricingPeriods { get; set; } = new List<PricingPeriod>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
