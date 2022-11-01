
using System.ComponentModel.DataAnnotations;
using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class AutorCrearActualizarDto
{
    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Nombre {get; set;}
}
