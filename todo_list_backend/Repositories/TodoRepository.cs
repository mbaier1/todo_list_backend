using todo_list_backend.Data;
using todo_list_backend.Data.Models;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Repositories;

public class TodoRepository(TodoListDbContext _context) : ITodoRepository
{
    public List<TodoItem> GetTodoItems()
    {
        return _context.TodoItems.ToList();
    }

    public TodoItem GetTodoItem(Guid id)
    {
        return _context.TodoItems.Single(x => x.Id == id);
    }

    public void AddTodoItem(TodoItem todoItemModel)
    {
        _context.TodoItems.Add(todoItemModel);
        _context.SaveChanges();
    }

    public void DeleteTodoItem(TodoItem todoItem)
    {
        _context.TodoItems.Remove(todoItem);
        _context.SaveChanges();
    }
}
