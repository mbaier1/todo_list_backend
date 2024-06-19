using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers;

public class TodoItemModelToTodoItemDto : ITodoItemModelToTodoItemDto
{
    public TodoItemDto Map(TodoItem todoItem)
    {
        return new TodoItemDto
        {
            Id = todoItem.Id.ToString(),
            Description = todoItem.Description,
            Deadline = todoItem.Deadline,
            AreThereAdditionalDetails = todoItem.AreThereAdditionalDetails,
            AdditionalDetails = todoItem.AdditionalDetails
        };
    }
}
