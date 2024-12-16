using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class PrixodAudit
{
    public int Id { get; set; }

    public int IdZapici { get; set; }

    public int IdSotrud { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronicname { get; set; }

    public string Role { get; set; } = null!;

    public DateTime DateTimeZapici { get; set; }

    public int IdSessia { get; set; }
}
