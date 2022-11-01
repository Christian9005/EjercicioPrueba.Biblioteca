using Ejercicio.Prueba.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Prueba.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LibroController : ControllerBase
{
    private readonly ILibroAppService libroAppService;

    public LibroController(ILibroAppService libroAppService)
    {
        this.libroAppService = libroAppService;
    }

    [HttpGet]
    public ICollection<LibroDto> GetAll()
    {
        return libroAppService.GetAll();
    }

    [HttpPost]
    public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro)
    {
        return await libroAppService.CreateAsync(libro);
    }

    [HttpPut]
    public async Task UpdateAsync(int idLibro, LibroCrearActualizarDto libro)
    {
        await libroAppService.UpdateAsync(idLibro, libro);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int idLibro)
    {
        return await libroAppService.DeleteAsync(idLibro);
    }
}
