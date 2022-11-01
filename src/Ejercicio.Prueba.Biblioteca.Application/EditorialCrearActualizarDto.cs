using System.ComponentModel.DataAnnotations;
using Ejercicio.Prueba.Biblioteca.Domain;

namespace Ejercicio.Prueba.Biblioteca.Application;

public class EditorialCrearActualizarDto
{
    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Nombre {get; set;}
    
}
