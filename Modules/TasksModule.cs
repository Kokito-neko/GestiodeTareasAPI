using TaskManagerApi.Modules.Tasks.Repositories;
using TaskManagerApi.Modules.Tasks.Services;

namespace TaskManagerApi.Modules.Tasks;

public static class TasksModule 
{
    public static IServiceCollection AddTasksModule(this IServiceCollection services) 
    {
        services.AddScoped<TasksService>();
        services.AddScoped<TasksRepository>();
        return services;
    }
}