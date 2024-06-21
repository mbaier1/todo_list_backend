using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers;

public class TodoItemDtoToTodoItemMapper : ITodoItemDtoToTodoItemMapper
{
    public TodoItem Map(TodoItemDto todoItemDto)
    {
        return new TodoItem
        {
            Description = todoItemDto.Description,
            Deadline = todoItemDto.Deadline,
            AreThereAdditionalDetails = todoItemDto.AreThereAdditionalDetails,
            AdditionalDetails = todoItemDto.AdditionalDetails,
            TodoIsOverdue = todoItemDto.TodoIsOverdue,
            TodoIsCompleted = todoItemDto.TodoIsCompleted
        };
    }
}
