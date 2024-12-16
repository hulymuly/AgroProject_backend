using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Sotrudniki
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string? Patronicname { get; set; }
}
