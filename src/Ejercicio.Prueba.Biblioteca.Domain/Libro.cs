using System.ComponentModel.DataAnnotations;

namespace Ejercicio.Prueba.Biblioteca.Domain;

public class Libro
{
    [Required]
    public int Id {get; set;}

    [Required]
    [StringLength(Constantes.NOMBRE_MAX_LEN)]
    public string Titulo {get; set;}

    [Required]
    public int AutorId {get; set;}
    public virtual Autor Autor {get; set;}

    [Required]
    public int EditorialId {get; set;}
    public virtual Editorial Editorial {get; set;}

    [Required]
    public long Paginas {get; set;}

    [Required]
    public DateTime Fecha {get; set;}
    
}
