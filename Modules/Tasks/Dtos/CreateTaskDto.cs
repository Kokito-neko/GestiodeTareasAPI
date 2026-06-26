using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Modules.Tasks.Dtos;

public class CreateTaskDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    [MinLength(3, ErrorMessage = "El título debe tener mínimo 3 caracteres")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [MinLength(3, ErrorMessage = "La descripción debe tener mínimo 3 caracteres")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "La prioridad es obligatoria")]
    [MinLength(3, ErrorMessage = "La prioridad debe tener mínimo 3 caracteres")]
    public required string Priority { get; set; } // Ejemplo: Alta, Media, Baja
}