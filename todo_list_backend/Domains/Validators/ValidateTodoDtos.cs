using System.Linq.Expressions;
using todo_list_backend.Domains.Validators.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Validators;

public class ValidateTodoDtos : IValidateTodoDtos
{
    public void IsTodoItemDtoValid(TodoItemDto todoItemDto)
    {
        if (ValueIsEmpty(todoItemDto.Description) || ValueIsEmpty(todoItemDto.Deadline))
            throw new Exception("Values for Description and Deadline must have value");
    }

    public void IsSubTodoItemDtoValid(SubTodoItemDto subTodoItemDto)
    {
        if (ValueIsEmpty(subTodoItemDto.Description))
            throw new Exception("Value for Description must have value");
    }

    private bool ValueIsEmpty(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            return true;

        return false;
    }
}
