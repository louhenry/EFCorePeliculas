namespace EFCorePeliculas.Entidades
{
    public class PeliculaActor
    {
        public Guid PeliculaId { get; set; }
        public Guid ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
