using todo_list_backend.Data;
using todo_list_backend.Data.Models;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Repositories;

public class TodoRepository(TodoListDbContext _context) : ITodoRepository
{
    public List<TodoItem> GetTodos()
    {
        return _context.TodoItems.ToList();
    }

    public void AddTodoItem(TodoItem todoItemModel)
    {
        _context.TodoItems.Add(todoItemModel);
        _context.SaveChanges();
    }
}
