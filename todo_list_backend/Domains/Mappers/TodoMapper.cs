using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers;

public class TodoMapper(ISubTodoListMapper _subTodoMapper) : ITodoMapper
{
    private const int SUB_TODO_MAXIMUM_AMOUNT = 2;
    public TodoItem ToTodoItem(TodoItemDto todoItemDto)
    {
        return new TodoItem
        {
            Id = DetermineGuidId(todoItemDto.Id),
            Description = todoItemDto.Description,
            Deadline = todoItemDto.Deadline,
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
            AreThereAdditionalDetails = !string.IsNullOrEmpty(todoItem.AdditionalDetails),
            AdditionalDetails = todoItem.AdditionalDetails,
            TodoIsOverdue = todoItem.TodoIsOverdue,
            TodoIsCompleted = todoItem.TodoIsCompleted,
            HasLessThanTwoSubTodos = todoItem.SubTodoItems == null || todoItem.SubTodoItems.Count < SUB_TODO_MAXIMUM_AMOUNT,
            SubTodoItems = todoItem.SubTodoItems != null ? _subTodoMapper.ToSubTodoItemDtos(todoItem.SubTodoItems.ToList()) : new List<SubTodoItemDto>()
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
