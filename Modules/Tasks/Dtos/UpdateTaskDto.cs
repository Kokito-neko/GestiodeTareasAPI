using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Modules.Tasks.Dtos;

public class UpdateTaskDto 
{
    [MinLength(3, ErrorMessage = "El título debe tener mínimo 3 caracteres")]
    public string? Title { get; set; }

    [MinLength(3, ErrorMessage = "La descripción debe tener mínimo 3 caracteres")]
    public string? Description { get; set; }

    [MinLength(3, ErrorMessage = "La prioridad debe tener mínimo 3 caracteres")]
    public string? Priority { get; set; }
}