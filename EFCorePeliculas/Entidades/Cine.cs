using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        //[Precision(precision:9,scale:2)]
        //public decimal Precio { get; set; }
        public CineOferta CineOferta { get; set; }
        public List<SalaDeCine> SalasDeCine { get; set; }

    }
}
