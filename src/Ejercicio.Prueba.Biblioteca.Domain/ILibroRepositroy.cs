using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Prueba.Biblioteca.Domain;
public interface ILibroRepository: IRepository<Libro>
{
    Task<bool> ExisteLibro(string titulo);
    
    Task<bool> ExisteLibro(string titulo, int idLibro);
    
}