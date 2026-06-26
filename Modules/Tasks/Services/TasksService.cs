using WebApiLayerArchitecture.Modules.Tasks.Dtos;
using WebApiLayerArchitecture.Modules.Tasks.Entities;

namespace WebApiLayerArchitecture.Modules.Tasks.Services;

public class TasksService
{
    // Lista estática en memoria que simula la base de datos con dos tareas iniciales
    private readonly static List<TodoTask> tasks = [
        new TodoTask {
            Title = "Aprender Arquitectura Modular",
            Description = "Comprender la separación de responsabilidades en capas",
            Priority = "Alta"
        },
        new TodoTask {
            Title = "Probar endpoints en Postman",
            Description = "Asegurar que los métodos HTTP respondan correctamente",
            Priority = "Media"
        }
    ];

    // 1. Obtener todas las tareas
    public List<TodoTask> FindAll()
    {
        return tasks;
    }

    // 2. Obtener una sola tarea por su UUID
    public TodoTask? FindOne(Guid uuid)
    {
        return tasks.FirstOrDefault((t) => t.Uuid == uuid);
    }

    // 3. Crear una nueva tarea
    public TodoTask Create(CreateTaskDto taskDto)
    {
        TodoTask task = new() {
            Title = taskDto.Title,
            Description = taskDto.Description,
            Priority = taskDto.Priority
        };
        tasks.Add(task);
        return task;
    }

    // 4. Actualizar parcialmente una tarea (PATCH)
    public TodoTask? Update(Guid uuid, UpdateTaskDto taskDto)
    {
        TodoTask? task = FindOne(uuid);
        if (task is null) return null;

        // Si el usuario envió el dato, lo actualiza; si vino nulo, no lo toca
        if (taskDto.Title is not null) task.Title = taskDto.Title;
        if (taskDto.Description is not null) task.Description = taskDto.Description;
        if (taskDto.Priority is not null) task.Priority = taskDto.Priority;

        return task;
    }

    // 5. Eliminar una tarea por su UUID
    public bool DeleteOne(Guid uuid)
    {
        TodoTask? task = FindOne(uuid);
        if (task is null) return false;

        tasks.Remove(task);
        return true;
    }
}