using System;
using System.Collections.Generic;

namespace MyProject.Models;

public partial class User
{
    public string? Role { get; set; }

    public string? Fio { get; set; }

    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
