using Microsoft.EntityFrameworkCore;
using todo_list_backend.Data.Models;

namespace todo_list_backend.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(x =>
            x.HasMany(t => t.SubTodoItems)
            .WithOne()
            .HasForeignKey(s => s.Id)
        );
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<SubTodoItem> SubTodoItems { get; set; }
}
