using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain;

public enum PartnershipLevel
{

    [Display(Name = "Партнер" )]
    Partner = 0,
    [Display(Name = "Генеральний партнер")]
    GeneralPartner = 1,
    [Display(Name = "Співорганізатор")]
    CoOrganiser = 2
}
