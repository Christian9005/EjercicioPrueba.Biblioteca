using Ejercicio.Prueba.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Prueba.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorAppService autorAppService;
    public AutorController(IAutorAppService autorAppService)
    {
        this.autorAppService = autorAppService;
    }

    [HttpGet]
    public ICollection<AutorDto> GetAll()
    {
        return autorAppService.GetAll();
    }

    [HttpPost]
    public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor)
    {
        return await autorAppService.CreateAsync(autor);
    }

    [HttpPut]
    public async Task UpdateAsync(int idAutor, AutorCrearActualizarDto autor)
    {
        await autorAppService.UpdateAsync(idAutor, autor);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int idAutor)
    {
        return await autorAppService.DeleteAsync(idAutor);
    }

}
