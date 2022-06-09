using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Con esto, ya no es necesario declarar la precision en todos los campos
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<decimal>().HavePrecision(precision: 9, scale: 2);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                .IsRequired();

            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre).HasMaxLength(100).IsRequired();
            
            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.Precio).HasPrecision(precision: 9, scale: 2);
            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.TipoSalaDeCine).HasDefaultValue(TipoSalaDeCine.DosDimensiones);

            modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Pelicula>().Property(prop => prop.Titulo).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterURL).IsUnicode(false);

            modelBuilder.Entity<CineOferta>().Property(prop => prop.PorcentajeDescuento).HasPrecision(precision: 5, scale: 2);
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaInicio).HasColumnType("date");
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaFin).HasColumnType("date");

            modelBuilder.Entity<PeliculaActor>().HasKey(prop => new { prop.PeliculaId, prop.ActorId });


        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
