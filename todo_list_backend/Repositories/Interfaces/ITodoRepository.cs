using todo_list_backend.Data.Models;

namespace todo_list_backend.Repositories.Interfaces;

public interface ITodoRepository
{
    void AddTodoItem(TodoItem todoItemModel);
    List<TodoItem> GetTodoItems();
    TodoItem GetTodoItem(Guid id);
    void UpdateTodoItem(TodoItem todoItemModel);
    void DeleteTodoItem(TodoItem todoItem);
}
