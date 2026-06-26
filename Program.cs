//Estas son las importaciones

using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data;
using TaskManagerApi.Modules.Tasks;

//Este es el constructor, encargado de unir todas las herramientas Api
var builder = WebApplication.CreateBuilder(args);

//Le permite al constructor crear doc. auto. y usar los controladores
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//Registra los modulos de tareas
builder.Services.AddTasksModule();

//Conecta el código a la base de datos 
builder.Services.AddDbContext<AppDbContext>(option => {
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

var app = builder.Build();

//Es una regla de seguridad
if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();
    

app.UseHttpsRedirection();
app.MapControllers();

//Es el pueryo donde corre el servidor local
app.Run("http://localhost:3000");}