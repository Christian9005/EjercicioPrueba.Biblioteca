using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class LibroAppService : ILibroAppService
{
    private readonly ILibroRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public LibroAppService(ILibroRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto)
    {
        var existeTituloLibro = await repository.ExisteLibro(libroDto.Titulo);
        if (existeTituloLibro)
        {
            throw new ArgumentException($"Libro con el titulo: {libroDto.Titulo} ya registrado!!");
        }

        var libro = new Libro();
        libro.Titulo = libroDto.Titulo;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;
        libro.Fecha = libroDto.Fecha;
        libro.Paginas = libroDto.Paginas;

        libro = await repository.AddAsync(libro);
        await unitOfWork.SaveChangesAsync();

        var libroCreado = new LibroDto();
        libroCreado.Id = libro.Id;
        libroCreado.Titulo = libro.Titulo;
        libroCreado.AutorId = libro.AutorId;
        //libroCreado.Autor = libro.Autor.Nombre;
        libroCreado.EditorialId = libro.EditorialId;
        //libroCreado.Editorial = libro.Editorial.Nombre;
        libroCreado.Fecha = libro.Fecha;
        libroCreado.Paginas = libro.Paginas;

        return libroCreado;
    }

    public async Task<bool> DeleteAsync(int idLibro)
    {
        var libro = await repository.GetByIdAsync(idLibro);
        if (libro == null)
        {
            throw new ArgumentException($"El libro con el id: {idLibro}, no existe!!");
        }

        repository.Delete(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<LibroDto> GetAll()
    {
        var libroList = repository.GetAll();

        var libroListDto = from li in libroList
                           select new LibroDto(){
                            Id = li.Id,
                            Titulo = li.Titulo,
                            AutorId = li.AutorId,
                            Autor = li.Autor.Nombre,
                            EditorialId = li.EditorialId,
                            Editorial = li.Editorial.Nombre,
                            Paginas = li.Paginas,
                            Fecha = li.Fecha
                           };
        
        return libroListDto.ToList();
    }

    public async Task UpdateAsync(int idLibro, LibroCrearActualizarDto libroDto)
    {
        var libro = await repository.GetByIdAsync(idLibro);
        if (libro == null)
        {
            throw new ArgumentException($"El libro con el id: {idLibro}, no existe!!");
        }

        var existeTituloLibro = await repository.ExisteLibro(libroDto.Titulo, idLibro);
        if (existeTituloLibro)
        {
            throw new ArgumentException($"El libro con el titulo: {libroDto.Titulo}, ya existe existe!!");
        }

        libro.Titulo = libroDto.Titulo;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;
        libro.Fecha = libroDto.Fecha;
        libro.Paginas = libroDto.Paginas;

        await repository.UpdateAsync(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return;

    }
}
