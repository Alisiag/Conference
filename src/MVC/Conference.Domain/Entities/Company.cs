using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
