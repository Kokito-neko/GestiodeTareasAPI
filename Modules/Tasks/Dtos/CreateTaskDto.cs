namespace TaskManagerApi.Modules.Tasks.Dtos;

public class CreateTaskDto 
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Priority { get; set; }
}