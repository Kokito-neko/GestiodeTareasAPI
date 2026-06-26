using TaskManagerApi.Data;
using TaskManagerApi.Modules.Tasks.Entities;

namespace TaskManagerApi.Modules.Tasks.Repositories; //ubica el archivo

public class TasksRepository(AppDbContext dbContext) //usa inyecciones de dependencia para recibir a ...
{
    private readonly AppDbContext _dbContext = dbContext; //permite comunicarse con docker

    public List<TodoTask> FindAll() => _dbContext.Tasks.ToList(); //traduce el comando a codigo

    public TodoTask? FindOne(int id) => _dbContext.Tasks.Find(id);

    public TodoTask Create(TodoTask task) 
    {
        _dbContext.Tasks.Add(task); //prepara la nueva tarea
        _dbContext.SaveChanges(); //ejecuta la orden en docker y postgresql la guarda
        return task;
    }

    public TodoTask Update(TodoTask task) 
    {
        _dbContext.Tasks.Update(task); //revisa que se actualizo
        _dbContext.SaveChanges();
        return task;
    }

    public void Delete(int id) 
    {
        var task = FindOne(id); //busca si la tarea existe
        if (task is not null) 
        {
            _dbContext.Tasks.Remove(task); //la borra
            _dbContext.SaveChanges(); //ejecuta en comando sql en docker para borrarla
        }
    }
}