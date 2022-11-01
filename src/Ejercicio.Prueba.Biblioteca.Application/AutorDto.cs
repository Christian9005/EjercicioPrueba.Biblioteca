using System.ComponentModel.DataAnnotations;
using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class AutorDto
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Nombre {get; set;}
}
