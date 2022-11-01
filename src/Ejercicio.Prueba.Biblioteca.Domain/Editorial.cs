using System.ComponentModel.DataAnnotations;
namespace Ejercicio.Prueba.Biblioteca.Domain;
public class Editorial
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Nombre {get; set;}
    
    
}