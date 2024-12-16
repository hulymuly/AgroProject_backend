using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Etiketka
{
    public int Id { get; set; }

    public string? Kultura { get; set; }

    public string? Sort { get; set; }

    public string? Reprodukcia { get; set; }

    public int? GodUrozhaia { get; set; }

    public string? PrtiaNomer { get; set; }

    public decimal? MassaPrtii { get; set; }

    public string? KontrilEdenitca { get; set; }

    public string? VidAnaliza { get; set; }
}
