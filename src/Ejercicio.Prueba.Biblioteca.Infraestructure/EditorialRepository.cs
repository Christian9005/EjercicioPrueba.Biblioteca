using Ejercicio.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Biblioteca.Infraestructure;

public class EditorialRepository : EfRepository<Editorial>, IEditorialRepository
{
    public EditorialRepository(EjercicioPruebaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteEditorial(string nombre)
    {
        var resultado = await this._context.Set<Editorial>()
                                  .AnyAsync(e => e.Nombre.ToUpper() == nombre.ToUpper());
        return resultado;
    }

    public async Task<bool> ExisteEditorial(string nombre, int idEditorial)
    {
        var query = this._context.Set<Editorial>()
                         .Where(e => e.Id != idEditorial)
                         .Where(e => e.Nombre.ToUpper() == nombre.ToUpper());

        var resultado = await query.AnyAsync();

        return resultado;
    }
}
