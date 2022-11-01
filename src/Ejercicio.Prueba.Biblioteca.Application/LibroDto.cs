
using System.ComponentModel.DataAnnotations;
using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class LibroDto
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Titulo {get; set;}

    [Required]
    public int AutorId {get; set;}
    public string Autor {get; set;}

    [Required]
    public int EditorialId {get; set;}
    public string Editorial {get; set;}

    [Required]
    public long Paginas {get; set;}

    [Required]
    public DateTime Fecha {get; set;}
    
}
