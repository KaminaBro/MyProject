using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class PickupPoint
{
    public string Index { get; set; } = null!;

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
