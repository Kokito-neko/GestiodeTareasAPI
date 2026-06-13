using System.ComponentModel.DataAnnotations;

namespace WebApiLayerArchitecture.Modules.Tasks.Dtos;

public class CreateTaskDto
{
    [Required(ErrorMessage = "El título es requerido")]
    [MinLength(3, ErrorMessage = "El título debe tener mínimo 3 caracteres")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "La descripción es requerida")]
    [MinLength(3, ErrorMessage = "La descripción debe tener mínimo 3 caracteres")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "La prioridad es requerida")]
    [MinLength(3, ErrorMessage = "La prioridad debe tener mínimo 3 caracteres")]
    public required string Priority { get; set; }
}