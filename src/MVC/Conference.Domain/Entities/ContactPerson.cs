using System;
using System.Collections.Generic;

namespace ConferenceMVC.Domain.Entities;

public partial class ContactPerson : Entity
{

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int InvoiceId { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
