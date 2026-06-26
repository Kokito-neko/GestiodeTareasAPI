using WebApiLayerArchitecture.Modules.Tasks.Services;

namespace WebApiLayerArchitecture.Modules.Tasks;

public static class TasksModule
{
    public static IServiceCollection AddTasksModule(this IServiceCollection services)
    {
        // Registra el servicio con ciclo de vida Scoped en el sistema de .NET
        services.AddScoped<TasksService>();
        return services;
    }
}