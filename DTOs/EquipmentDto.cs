namespace AgroProject.DTOs
{
    public class EquipmentDto
    {
        public int? Id { get; set; } // ID для обновления
        public string Name { get; set; } = null!;
        public string? Kategoria { get; set; }
        public string? Model { get; set; }
        public int? NomerInvent { get; set; }
        public string? NomerZavod { get; set; }
        public DateTime? DataVvodaVExpluataciu { get; set; }
        public string? NomerSvidetelstva { get; set; }
        public DateTime? DataProverki { get; set; }
        public DateTime? GodenDo { get; set; }
        public decimal? Diametr { get; set; }
        public decimal? Dlinna { get; set; }
        public decimal? Visota { get; set; }
        public decimal? Glubina { get; set; }
        public decimal? Shirina { get; set; }
        public DateTime? DataVivodaIzIspolz { get; set; }
    }
}
