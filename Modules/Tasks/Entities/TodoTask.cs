using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Modules.Tasks.Entities;

public class TodoTask 
{
    [Key] // Es una etiqueta, le avisa a EF que la columna id es la llave primaria 
    public int Id { get; set; } // El identificador será de número entero

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; } // Ejemplo: Alta, Media, Baja
}