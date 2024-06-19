using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Todo;

public class CreateTodo : ICreateTodo
{
    public void Create(TodoItemDto todoItemDto)
    {
        var id = Guid.NewGuid();
    }
}
