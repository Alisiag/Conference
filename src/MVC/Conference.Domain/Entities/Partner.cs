using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Partner
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PartnershipLevel { get; set; }

    public int ConferenceId { get; set; }

    public virtual Conference Conference { get; set; } = null!;
}
