namespace WebApiLayerArchitecture.Modules.Tasks.Entities;

public class TodoTask
{
    // Genera automáticamente un ID único en formato UUID para cada tarea
    public Guid Uuid { get; } = Guid.NewGuid();
    
    // Las propiedades obligatorias que definen a nuestra tarea
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; } // Ejemplo: Alta, Media, Baja
}