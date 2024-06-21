using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Todo.Interfaces;

public interface ITodoDomain
{
    void CreateTodo(TodoItemDto todoItemDto);
    List<TodoItemDto> GetTodos();
    void UpdateTodo(TodoItemDto todoItemDto);
    void DeleteTodo(string id);
}
