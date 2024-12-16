using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Sessium
{
    public int Id { get; set; }

    public int IdPolzovat { get; set; }

    /// <summary>
    /// ДатаВремя создания сессии
    /// </summary>
    public DateTime DateTimeSozd { get; set; }
}
