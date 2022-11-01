
using Ejercicio.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Biblioteca.Infraestructure;

public class LibroRepository : EfRepository<Libro>, ILibroRepository
{
    public LibroRepository(EjercicioPruebaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteLibro(string titulo)
    {
        var resultado = await this._context.Set<Libro>()
                                  .AnyAsync(li => li.Titulo.ToUpper() == titulo.ToUpper());
        return resultado;
    }

    public async Task<bool> ExisteLibro(string titulo, int idLibro)
    {
        var query = this._context.Set<Libro>()
                         .Where(li => li.Id != idLibro)
                         .Where(li => li.Titulo.ToUpper() == titulo.ToUpper());

        var resultado = await query.AnyAsync();

        return resultado;
    }
}
