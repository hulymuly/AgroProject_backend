using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class ReaktivPrixod
{
    public int Id { get; set; }

    public int Reaktiv { get; set; }

    public string? DataPrixoda { get; set; }

    public string? Chistota { get; set; }

    public string? Polucheno { get; set; }

    public DateOnly? DataIzgotovlenia { get; set; }

    public string? GodenDo { get; set; }

    public string? Postavshik { get; set; }

    public string? Partia { get; set; }
}
