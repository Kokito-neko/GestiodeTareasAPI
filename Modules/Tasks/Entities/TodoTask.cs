<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Modules.Tasks.Entities;

public class TodoTask 
{
    [Key] // es una etiqueta, le avisa a EF, que la clumna id e la llave primaria 
    public int Id { get; set; } // el indicador sera de numero entero
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; }
=======
namespace WebApiLayerArchitecture.Modules.Tasks.Entities;

public class TodoTask
{
    // Genera automáticamente un ID único en formato UUID para cada tarea
    public Guid Uuid { get; } = Guid.NewGuid();
    
    // Las propiedades obligatorias que definen a nuestra tarea
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; } // Ejemplo: Alta, Media, Baja
>>>>>>> 9da3acfb0156b05053fb0248630aa920938efa06
}