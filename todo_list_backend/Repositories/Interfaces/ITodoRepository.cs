using todo_list_backend.Data.Models;

namespace todo_list_backend.Repositories.Interfaces;

public interface ITodoRepository
{
    List<TodoItem> GetTodoItems();
    TodoItem GetTodoItem(Guid id);
    void AddTodoItem(TodoItem todoItemModel);
    void DeleteTodoItem(TodoItem todoItem);
}
