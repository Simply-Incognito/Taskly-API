using TaskCoreAPI.Exceptions;
using TaskCoreAPI.Middlewares;
using Taskly.Repositories;
using Taskly.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
// TaskItemService depends on ITaskRepository (scoped). Use scoped lifetime to avoid consuming a scoped service from a singleton.
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

var app = builder.Build();

// Middlewares
app.UseMiddleware<GlobaExceptionMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
