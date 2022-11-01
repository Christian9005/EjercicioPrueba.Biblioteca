using Ejercicio.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Biblioteca.Infraestructure;

public class EjercicioPruebaDbContext: DbContext, IUnitOfWork
{
    public EjercicioPruebaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ejercicio.prueba-biblioteca.db");
    }

    public DbSet<Autor> Autors {get; set;}
    public DbSet<Editorial> Editorials {get; set;}
    public DbSet<Libro> Libros {get; set;}

    public string DbPath {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
                            => options.UseSqlite($"Data Source={DbPath}");
    
}
