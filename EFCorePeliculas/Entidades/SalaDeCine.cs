namespace EFCorePeliculas.Entidades
{
    public class SalaDeCine
    {
        public Guid Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public Guid CineId { get; set; }
        public Cine Cine { get; set; }
        public List<Pelicula>Peliculas { get; set; }

    }
}
