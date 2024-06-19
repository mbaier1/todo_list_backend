using todo_list_backend.Data.Models;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers.Interfaces;

public interface ITodoItemModelToTodoItemDto
{
    TodoItemDto Map(TodoItem todoItem);
}
