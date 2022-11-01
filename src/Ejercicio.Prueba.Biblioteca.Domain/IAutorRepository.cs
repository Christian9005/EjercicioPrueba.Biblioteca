

namespace Ejercicio.Prueba.Biblioteca.Domain;

public interface IAutorRepository: IRepository<Autor>
{
    Task<bool> ExisteAutor(string nombre);
    
    Task<bool> ExisteAutor(string nombre, int idAutor);
    
}



