using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class ZakazchikAudit
{
    public int Id { get; set; }

    public int IdZapici { get; set; }

    public int IdSotrud { get; set; }

    public string NameSotr { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronicname { get; set; }

    public DateTime? DateTimeZapici { get; set; }

    public int IdSessia { get; set; }
}
