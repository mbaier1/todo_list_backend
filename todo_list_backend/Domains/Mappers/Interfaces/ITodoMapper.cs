using todo_list_backend.Data.Models;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers.Interfaces
{
    public interface ITodoMapper
    {
        TodoItem ToTodoItem(TodoItemDto todoItemDto);
        TodoItemDto ToTodoItemDto(TodoItem todoItem);
        SubTodoItem ToSubTodoItem(string todoId, SubTodoItemDto subTodoItemDto);
    }
}
