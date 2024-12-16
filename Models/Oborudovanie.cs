using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Oborudovanie
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Kategoria { get; set; }

    public string? Model { get; set; }

    public int? NomerInvent { get; set; }

    public string? NomerZavod { get; set; }

    public DateOnly? DataVvodaVExpluataciu { get; set; }

    public string? NomerSvidetelstva { get; set; }

    public DateOnly? DataProverki { get; set; }

    public DateOnly? GodenDo { get; set; }

    public decimal? Diametr { get; set; }

    public decimal? Dlinna { get; set; }

    public decimal? Visota { get; set; }

    public decimal? Glubina { get; set; }

    public DateOnly? DataVivodaIzIspolz { get; set; }

    public decimal? Shirina { get; set; }
}
