namespace Ejercicio.Prueba.Biblioteca.Application;

public interface IAutorAppService
{
    ICollection<AutorDto> GetAll();
    Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto);
    Task UpdateAsync (int idAutor, AutorCrearActualizarDto autorDto);
    Task<bool> DeleteAsync (int idAutor);

}
