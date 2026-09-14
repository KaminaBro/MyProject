using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class Zakaz
{
    public int Quantity { get; set; }

    public DateOnly Date { get; set; }

    public string Address { get; set; } = null!;

    public string Login { get; set; } = null!;

    public int Code { get; set; }

    public string Status { get; set; } = null!;

    public int Id { get; set; }

    public string? Articul { get; set; }

    public virtual PickupPoint AddressNavigation { get; set; } = null!;

    public virtual Tovar? ArticulNavigation { get; set; }

    public virtual User LoginNavigation { get; set; } = null!;
}
