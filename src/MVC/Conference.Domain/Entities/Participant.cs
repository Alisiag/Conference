using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Participant : Entity
{

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int ConferenceId { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Ticket? Ticket { get; set; }
}
