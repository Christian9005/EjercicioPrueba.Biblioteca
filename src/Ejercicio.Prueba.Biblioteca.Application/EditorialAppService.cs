using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class EditorialAppService : IEditorialAppService
{
    private readonly IEditorialRepository repository;
    private readonly IUnitOfWork unitOfwork;

    public EditorialAppService(IEditorialRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfwork = unitOfWork;
    }

    public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorialDto)
    {
        var existeNombreEditorial = await repository.ExisteEditorial(editorialDto.Nombre);
        if (existeNombreEditorial)
        {
           throw new ArgumentException($"Ya existe la editorial con el nombre: {editorialDto.Nombre}!!"); 
        }

        var editorial = new Editorial();
        editorial.Nombre = editorialDto.Nombre;
        
        editorial = await repository.AddAsync(editorial);
        await unitOfwork.SaveChangesAsync();

        var editorialCreada = new EditorialDto();
        editorialCreada.Id = editorial.Id;
        editorialCreada.Nombre = editorial.Nombre;

        return editorialCreada;
    }

    public async Task<bool> DeleteAsync(int idEditorial)
    {
        var editorial = await repository.GetByIdAsync(idEditorial);
        if (editorial == null)
        {
            throw new ArgumentException($"La editorial con el id: {idEditorial}, no existe!!");
        }

        repository.Delete(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;

    }

    public ICollection<EditorialDto> GetAll()
    {
        var editorialList = repository.GetAll();

        var editorialListDto = from e in editorialList
                               select new EditorialDto(){
                                Id = e.Id,
                                Nombre = e.Nombre
                               };
        
        return editorialListDto.ToList();
    }

    public async Task UpdateAsync(int idEditorial, EditorialCrearActualizarDto editorialDto)
    {
        var editorial = await repository.GetByIdAsync(idEditorial);
        if (editorial == null)
        {
            throw new ArgumentException($"La editorial con el id: {idEditorial}, no existe!!");
        }

        var existeNombreEditorial = await repository.ExisteEditorial(editorialDto.Nombre, idEditorial);
        if (existeNombreEditorial)
        {
            throw new ArgumentException($"La editorial con el nombre: {editorialDto.Nombre}, ya existe!!");
        }

        editorial.Nombre = editorialDto.Nombre;

        await repository.UpdateAsync(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
