using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class Tovar
{
    public string Article { get; set; } = null!;

    public string? NameTovar { get; set; }

    public string? Unit { get; set; }

    public int? Price { get; set; }

    public string? Supplier { get; set; }

    public string? Category { get; set; }

    public int? Discount { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public string? Manufacture { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
