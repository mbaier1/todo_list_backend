using todo_list_backend.Data.Models;
using todo_list_backend.DTOs;

namespace todo_list_backend.Repositories.Interfaces;

public interface ITodoRepository
{
    void AddTodoItem(TodoItem todoItemModel);
    void AddSubTodoItem(SubTodoItem subTodoItemModel);
    List<TodoItem> GetTodoItems();
    TodoItem GetTodoItem(Guid id);
    SubTodoItem GetSubTodoItem(Guid id);
    void UpdateTodoItem(TodoItem todoItemModel);
    void UpdateSubTodoItem(SubTodoItem subTodoItemModel);
    void DeleteTodoItem(TodoItem todoItem);
    void DeleteSubTodoItem(SubTodoItem subTodoItemModel);
}
