namespace EFCorePeliculas.Entidades
{
    public class CineOferta
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public Guid CineId { get; set; }

    }
}
