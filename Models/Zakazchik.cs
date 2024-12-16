using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Zakazchik
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Adress { get; set; }

    public int? Inn { get; set; }
}
