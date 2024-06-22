using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers;

public class TodoMapper : ITodoMapper
{
    public TodoItem ToTodoItem(TodoItemDto todoItemDto)
    {
        return new TodoItem
        {
            Id = DetermineGuidId(todoItemDto.Id),
            Description = todoItemDto.Description,
            Deadline = todoItemDto.Deadline,
            AreThereAdditionalDetails = todoItemDto.AreThereAdditionalDetails,
            AdditionalDetails = todoItemDto.AdditionalDetails,
            TodoIsOverdue = todoItemDto.TodoIsOverdue,
            TodoIsCompleted = todoItemDto.TodoIsCompleted
        };
    }

    public TodoItemDto ToTodoItemDto(TodoItem todoItem)
    {
        return new TodoItemDto
        {
            Id = todoItem.Id.ToString(),
            Description = todoItem.Description,
            Deadline = todoItem.Deadline,
            AreThereAdditionalDetails = todoItem.AreThereAdditionalDetails,
            AdditionalDetails = todoItem.AdditionalDetails,
            TodoIsOverdue = todoItem.TodoIsOverdue,
            TodoIsCompleted = todoItem.TodoIsCompleted,
        };
    }

    public SubTodoItem ToSubTodoItem(string todoId, SubTodoItemDto subTodoItemDto)
    {
        return new SubTodoItem
        {
            Id = DetermineGuidId(subTodoItemDto.Id),
            Description = subTodoItemDto.Description,
            AdditionalDetails = subTodoItemDto.AdditionalDetails,
            SubTodoIsOverdue = subTodoItemDto.SubTodoIsOverdue,
            SubTodoIsComplete = subTodoItemDto.SubTodoIsComplete,
            TodoId = DetermineGuidId(todoId)
        };
    }

    private Guid DetermineGuidId(string id)
    {
        return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
    }
}
