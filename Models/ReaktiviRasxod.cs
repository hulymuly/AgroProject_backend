using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class ReaktiviRasxod
{
    public int Id { get; set; }

    public int Reaktiv { get; set; }

    public DateOnly? Data { get; set; }

    public string? IzrasxodKolvo { get; set; }

    public string? Rastvor { get; set; }

    public string? MetodikaGost { get; set; }

    public string? RastvorKolvo { get; set; }

    public string? Xranenie { get; set; }

    public DateOnly? GodenDo { get; set; }
}
