using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades
{
    public class Genero
    {
        public Guid Id { get; set; }
        //[Required]
        public string Nombre { get; set; }
    }
}
