namespace Ejercicio.Prueba.Biblioteca.Application;

public interface IEditorialAppService
{
    ICollection<EditorialDto> GetAll();
    Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorialDto);
    Task UpdateAsync (int idEditorial, EditorialCrearActualizarDto editorialDto);
    Task<bool> DeleteAsync (int idEditorial);
}
