using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Modules.Tasks.Entities;

public class TodoTask 
{
    [Key] // es una etiqueta, le avisa a EF, que la clumna id e la llave primaria 
    public int Id { get; set; } // el indicador sera de numero entero
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; }
}