using Microsoft.EntityFrameworkCore;
using todo_list_backend.Data;
using todo_list_backend.Domains.Calculators;
using todo_list_backend.Domains.Calculators.Interfaces;
using todo_list_backend.Domains.Mappers;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.Domains.Todo;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.Repositories;
using todo_list_backend.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InMemoryDb"));

builder.Services.AddTransient<ITodoDomain, TodoDomain>();
builder.Services.AddTransient<ITodoMapper, TodoMapper>();
builder.Services.AddTransient<ITodoDueDateCalculator, TodoDueDateCalculator>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

var reactTodoPolicy = "ReactTodoPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(reactTodoPolicy,
        builder => builder.WithOrigins("http://localhost:3000", "http://192.168.1.147:3000")
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(reactTodoPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
