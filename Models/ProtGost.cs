using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class ProtGost
{
    public int Id { get; set; }

    public string? NamePokazat { get; set; }

    public decimal? Rezult { get; set; }

    public string? DopustNorma { get; set; }
}
