using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class RegistraciaObrazcov
{
    public int Id { get; set; }

    public string? NomerNn { get; set; }

    public int Zakazchik { get; set; }

    public string? ZaiavkaNaIspitanie { get; set; }

    public string? DogovorNomer { get; set; }

    public string? SertifikNomerData { get; set; }

    public DateOnly? DataPostupObraz { get; set; }

    public string? SrokIspitania { get; set; }

    public string? Kulture { get; set; }

    public string? Sort { get; set; }

    public int? KodObrazcta { get; set; }

    public string? OtborProvelKto { get; set; }

    public string? AktOtbora { get; set; }

    public string? GodUrozhaia { get; set; }

    public string? Napravlenie { get; set; }

    public string? Reproduktcia { get; set; }

    public string? KategoriaSemyan { get; set; }

    public string? MassaObrazca { get; set; }

    public string? OtkudaPolucheni { get; set; }

    public string? MestoXranenia { get; set; }

    public string? NaznachenieSemyan { get; set; }

    public string? VidPodrabotki { get; set; }

    public string? VidAnaliza { get; set; }

    public string? Protokol { get; set; }
}
