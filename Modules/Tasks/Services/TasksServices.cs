//importa los formularios, entidades y el repositorio para coordinar todo un solo lugar
using TaskManagerApi.Modules.Tasks.Dtos;
using TaskManagerApi.Modules.Tasks.Entities;
using TaskManagerApi.Modules.Tasks.Repositories;

namespace TaskManagerApi.Modules.Tasks.Services;

public class TasksService(TasksRepository tasksRepository) 
{
    private readonly TasksRepository _tasksRepository = tasksRepository;

    public List<TodoTask> FindAll() => _tasksRepository.FindAll(); //busca todas las tablas

    public TodoTask? FindOne(int id) => _tasksRepository.FindOne(id); //busca por id y ? devorver un vacio si no existe

    public TodoTask Create(CreateTaskDto taskDto) 
    {
        TodoTask task = new() { //toma los datos y los guarda
            Title = taskDto.Title,
            Description = taskDto.Description,
            Priority = taskDto.Priority
        };
        return _tasksRepository.Create(task); //lo entrega ya listo al repositorio para que lo meta a postgresql
    }

    public TodoTask? Update(int id, UpdateTaskDto taskDto) 
    {
        TodoTask? task = FindOne(id); //verifica si existe
        if (task is null) return null;

        if (taskDto.Title is not null) task.Title = taskDto.Title;
        if (taskDto.Description is not null) task.Description = taskDto.Description;
        if (taskDto.Priority is not null) task.Priority = taskDto.Priority;

        return _tasksRepository.Update(task);
    }

    public bool DeleteOne(int id) 
    {
        TodoTask? task = FindOne(id);
        if (task is null) return false;

        _tasksRepository.Delete(id);
        return true;
    }
}