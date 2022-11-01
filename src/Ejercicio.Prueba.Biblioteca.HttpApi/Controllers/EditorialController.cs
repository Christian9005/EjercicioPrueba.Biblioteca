using Ejercicio.Prueba.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Prueba.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EditorialController : ControllerBase
{
    private readonly IEditorialAppService editorialAppService;

    public EditorialController(IEditorialAppService editorialAppService)
    {
        this.editorialAppService = editorialAppService;
    }

    [HttpGet]
    public ICollection<EditorialDto> GetAll()
    {
        return editorialAppService.GetAll();
    }

    [HttpPost]
    public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial)
    {
        return await editorialAppService.CreateAsync(editorial);
    }

    [HttpPut]
    public async Task UpdateAsync(int idEditorial, EditorialCrearActualizarDto editorial)
    {
        await editorialAppService.UpdateAsync(idEditorial, editorial);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int idEditorial)
    {
        return await editorialAppService.DeleteAsync(idEditorial);
    }
}
