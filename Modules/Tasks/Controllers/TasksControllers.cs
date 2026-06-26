using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Modules.Tasks.Dtos;
using TaskManagerApi.Modules.Tasks.Entities;
using TaskManagerApi.Modules.Tasks.Services;

namespace TaskManagerApi.Modules.Tasks.Controllers;

[ApiController]
[Route("/api/v1/[controller]")] //Define la url
public class TasksController(TasksService tasksService) : ControllerBase 
{
    private readonly TasksService _tasksService = tasksService;

    [HttpGet] //Responde 200 ok todas las tareas
    public IActionResult FindAll() => Ok(_tasksService.FindAll());

    [HttpGet("{id}")]
    public IActionResult FindOne(int id) 
    {
        TodoTask? task = _tasksService.FindOne(id);
        if (task == null) return NotFound(new { Message = "Tarea no encontrada." });
        return Ok(task);
    }

    [HttpPost]
    public IActionResult Create(CreateTaskDto taskDto) => Ok(_tasksService.Create(taskDto)); //crea atajo para guardar direccion del servidor web en la compu

    [HttpPatch("{id}")]
    public IActionResult Update(int id, UpdateTaskDto taskDto) 
    {
        TodoTask? taskUpdated = _tasksService.Update(id, taskDto);
        if (taskUpdated is null) return NotFound(new { Message = "Tarea no encontrada." });
        return Ok(new { Message = "Tarea actualizada" });
    }

      [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var deleted = _tasksService.DeleteOne(id); 
        
        if (!deleted) return NotFound("La tarea no existe."); //404 Not Found

        return NoContent(); //204 no content
    }
}