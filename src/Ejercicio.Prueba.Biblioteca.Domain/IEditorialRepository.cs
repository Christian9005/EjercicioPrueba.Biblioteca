using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Prueba.Biblioteca.Domain;

public interface IEditorialRepository: IRepository<Editorial>
{
    Task<bool> ExisteEditorial(string nombre);
    
    Task<bool> ExisteEditorial(string nombre, int idEditorial);
    
}