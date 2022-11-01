using Ejercicio.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Biblioteca.Infraestructure;

public class AutorRepository : EfRepository<Autor>, IAutorRepository
{
    public AutorRepository(EjercicioPruebaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteAutor(string nombre)
    {
        var resultado = await this._context.Set<Autor>()
                                  .AnyAsync(a => a.Nombre.ToUpper() == nombre.ToUpper());
        return resultado;
    }

    public async Task<bool> ExisteAutor(string nombre, int idAutor)
    {
        var query = this._context.Set<Autor>()
                         .Where(a => a.Id != idAutor)
                         .Where(a => a.Nombre.ToUpper() == nombre.ToUpper());

        var resultado = await query.AnyAsync();

        return resultado;
    }
}
