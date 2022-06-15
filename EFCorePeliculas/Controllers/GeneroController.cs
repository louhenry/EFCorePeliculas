using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/Generos")]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GeneroController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderBy(g => g.Nombre).ToListAsync();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Genero>> Get(Guid id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("Z"));
            
            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            return await context.Generos.Where(g => g.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> Paginacion(int pagina = 1)
        {
            var cantidadRegistrosPPag = 2;
            var generos = await context.Generos
                .Skip((pagina - 1) * cantidadRegistrosPPag)
                .Take(cantidadRegistrosPPag)
                .ToListAsync();
            return generos;
        }

        [HttpGet("IdNombreDTO")]
        public async Task<IEnumerable<GeneroDTO>> GetDTO()
        {
            return await context.Generos
                .ProjectTo<GeneroDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
