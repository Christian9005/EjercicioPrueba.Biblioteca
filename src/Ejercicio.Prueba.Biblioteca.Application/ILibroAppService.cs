namespace Ejercicio.Prueba.Biblioteca.Application;

public interface ILibroAppService
{
    ICollection<LibroDto> GetAll();
    Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto);
    Task UpdateAsync (int idLibro, LibroCrearActualizarDto libroDto);
    Task<bool> DeleteAsync (int idLibro);
}
