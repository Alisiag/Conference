using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class Speaker
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int ConferenceId { get; set; }

    public int CompanyId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
