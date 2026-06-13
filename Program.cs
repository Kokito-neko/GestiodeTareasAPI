using WebApiLayerArchitecture.Modules.Tasks; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTasksModule();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run("http://localhost:3000"); 