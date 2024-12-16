using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Protokol
{
    public int Id { get; set; }

    public string? NumberProtokola { get; set; }

    public int Zakazchik { get; set; }

    public string? OsnovanieZaiavka { get; set; }

    public string? NomerDogovoraData { get; set; }

    public string? ObektIspitania { get; set; }

    public string? ProvelOtborKto { get; set; }

    public DateOnly? DataPostupleniaObraztca { get; set; }

    public string? SrokIspitsnia { get; set; }

    public string? AktOtboraProb { get; set; }

    public string? NomerNapravleniaData { get; set; }

    public string? YsloviaProvedenia { get; set; }

    public string? KodObraztca { get; set; }

    public string? NapravlenieNaIssled { get; set; }

    public string? NdOtboraProb { get; set; }

    public string? TipOtbora { get; set; }
}
