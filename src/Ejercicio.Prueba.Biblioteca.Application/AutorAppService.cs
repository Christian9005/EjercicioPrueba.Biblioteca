using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class AutorAppService: IAutorAppService
{
    private readonly IAutorRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public AutorAppService(IAutorRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto)
    {
        var existeNombreAutor = await repository.ExisteAutor(autorDto.Nombre);
        if (existeNombreAutor)
        {
            throw new ArgumentException($"Ya existe el autor con el nombre: {autorDto.Nombre}!!");   
        }

        var autor = new Autor();
        autor.Nombre = autorDto.Nombre;

        autor = await repository.AddAsync(autor);
        await unitOfWork.SaveChangesAsync();

        var autorCreado = new AutorDto();
        autorCreado.Id = autor.Id;
        autorCreado.Nombre = autor.Nombre;

        return autorCreado;
    }

    public async Task<bool> DeleteAsync(int idAutor)
    {
        var autor = await repository.GetByIdAsync(idAutor);
        if (autor == null)
        {
            throw new ArgumentException($"El autor con el id: {idAutor}, no existe!!");
        }

        repository.Delete(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<AutorDto> GetAll()
    {
        var autorList = repository.GetAll();

        var autorListDto = from a in autorList
                           select new AutorDto(){
                            Id = a.Id,
                            Nombre = a.Nombre
                           };
        
        return autorListDto.ToList();
    }

    public async Task UpdateAsync(int idAutor, AutorCrearActualizarDto autorDto)
    {
        var autor = await repository.GetByIdAsync(idAutor);
        if (autor == null)
        {
            throw new ArgumentException($"El autor con el id: {idAutor}, no existe!!");
        }

        var existeNombreAutor = await repository.ExisteAutor(autorDto.Nombre, idAutor);
        if (existeNombreAutor)
        {
            throw new ArgumentException($"El autor con el nombre: {autorDto.Nombre}, ya existe!!");
        }

        autor.Nombre = autorDto.Nombre;

        await repository.UpdateAsync(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return;

    }
}
