using System;
using System.Collections.Generic;

namespace AgroProject.Models;

public partial class Reaktivi
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public int Quantity { get; set; } // Текущее количество на складе

    public int MinQuantity { get; set; } // Минимальное количество для уведомлений
}
