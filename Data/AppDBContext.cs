using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Modules.Tasks.Entities;

namespace TaskManagerApi.Data;

//Se crea la clase apdbcontext y la hereda dbcontext
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
    //Crea la tabla Tasks y su estructura como TodoTask
    public DbSet<TodoTask> Tasks => Set<TodoTask>();
}