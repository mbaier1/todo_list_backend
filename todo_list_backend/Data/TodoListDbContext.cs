using Microsoft.EntityFrameworkCore;
using todo_list_backend.Data.Models;

namespace todo_list_backend.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
}
