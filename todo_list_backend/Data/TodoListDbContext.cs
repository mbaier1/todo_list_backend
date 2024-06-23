using Microsoft.EntityFrameworkCore;
using todo_list_backend.Data.Models;

namespace todo_list_backend.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(x =>
            x.HasMany(s => s.SubTodoItems)
            .WithOne()
            .HasForeignKey(s => s.TodoId)
        );
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<SubTodoItem> SubTodoItems { get; set; }
}
