using Microsoft.AspNetCore.Mvc;
using WebApiLayerArchitecture.Modules.Tasks.Dtos;
using WebApiLayerArchitecture.Modules.Tasks.Entities;
using WebApiLayerArchitecture.Modules.Tasks.Services;

namespace WebApiLayerArchitecture.Modules.Tasks.Controllers;

[ApiController]
[Route("/api/v1/[controller]")] // Ruta: /api/v1/tasks
public class TasksController(TasksService tasksService) : ControllerBase
{
    private readonly TasksService _tasksService = tasksService;

    // 1. GET /api/v1/tasks -> Retorna 200 OK
    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_tasksService.FindAll());
    }

    // 2. GET /api/v1/tasks/{uuid} -> Retorna 200 OK o 404 Not Found
    [HttpGet("{uuid}")]
    public IActionResult FindOne(Guid uuid)
    {
        TodoTask? task = _tasksService.FindOne(uuid);
        if (task == null) {
            return NotFound(new { Message = "Tarea no encontrada." }); // 404 Not Found
        }
        return Ok(task); // 200 OK
    }

    // 3. POST /api/v1/tasks -> Retorna 201 Created (¡Corregido!)
    [HttpPost]
    public IActionResult Create(CreateTaskDto taskDto)
    {
        TodoTask newTask = _tasksService.Create(taskDto);
        // Usamos CreatedAtAction para devolver el estado 201 Created exacto que pide el profe
        return CreatedAtAction(nameof(FindOne), new { uuid = newTask.Uuid }, newTask);
    }

    // 4. PATCH /api/v1/tasks/{uuid} -> Retorna 200 OK o 404 Not Found
    [HttpPatch("{uuid}")]
    public IActionResult Update(Guid uuid, UpdateTaskDto taskDto)
    {
        TodoTask? taskUpdated = _tasksService.Update(uuid, taskDto);
        if (taskUpdated is null) {
            return NotFound(new { Message = "Tarea no encontrada." }); // 404 Not Found
        }
        return Ok(new { Message = "Tarea actualizada" }); // 200 OK
    }

    // 5. DELETE /api/v1/tasks/{uuid} -> Retorna 200 OK (¡Corregido!)
    [HttpDelete("{uuid}")]
    public IActionResult Delete(Guid uuid)
    {
        bool isDeleted = _tasksService.DeleteOne(uuid);
        if (!isDeleted) {
            return NotFound(new { Message = "Tarea no encontrada" }); // 404 Not Found
        }
        return Ok(new { Message = "Tarea eliminada correctamente" }); // 200 OK (Cambiado de 204 a 200 como pide la guía)
    }
}