using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Todo.Interfaces;

public interface ICreateTodo
{
    void Create(TodoItemDto todoItemDto);
}
