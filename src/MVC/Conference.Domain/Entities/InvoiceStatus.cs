using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConferenceMVC.Domain;

public enum InvoiceStatus
{
    [Display(Name = "Новий")]
    New = 0,
    [Display(Name = "Оплачено")]
    Paid = 1,
    [Display(Name = "Скасовано")]
    Cancelled = 2,
    [Display(Name = "Відправлено")]
    Sent = 3
}
