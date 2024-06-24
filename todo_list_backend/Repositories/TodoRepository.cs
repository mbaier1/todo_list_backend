using Microsoft.EntityFrameworkCore;
using todo_list_backend.Data;
using todo_list_backend.Data.Models;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Repositories;

public class TodoRepository(TodoListDbContext _context) : ITodoRepository
{
    public void AddTodoItem(TodoItem todoItemModel)
    {
        _context.TodoItems.Add(todoItemModel);
        _context.SaveChanges();
    }

    public void AddSubTodoItem(SubTodoItem subTodoItemModel)
    {
        _context.SubTodoItems.Add(subTodoItemModel);
        _context.SaveChanges();
    }

    public List<TodoItem> GetTodoItems()
    {
        return _context.TodoItems
            .Include(x => x.SubTodoItems)
            .ToList();
    }

    public TodoItem GetTodoItem(Guid id)
    {
        return _context.TodoItems.Single(x => x.Id == id);
    }
    public SubTodoItem GetSubTodoItem(Guid id)
    {
        return _context.SubTodoItems.Single(x => x.Id == id);
    }

    public void UpdateTodoItem(TodoItem todoItemModel)
    {
        _context.TodoItems.Update(todoItemModel);
        _context.SaveChanges();
    }
    public void UpdateSubTodoItem(SubTodoItem subTodoItemModel)
    {
        _context.SubTodoItems.Update(subTodoItemModel);
        _context.SaveChanges();
    }

    public void DeleteTodoItem(TodoItem todoItemModel)
    {
        _context.TodoItems.Remove(todoItemModel);
        _context.SaveChanges();
    }


    public void DeleteSubTodoItem(SubTodoItem subTodoItemModel)
    {
        _context.SubTodoItems.Remove(subTodoItemModel);
        _context.SaveChanges();
    }
}
