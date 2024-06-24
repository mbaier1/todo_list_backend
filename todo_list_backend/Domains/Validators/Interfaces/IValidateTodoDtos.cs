using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Validators.Interfaces;

public interface IValidateTodoDtos
{
    void IsTodoItemDtoValid(TodoItemDto todoItemDto);
    void IsSubTodoItemDtoValid(SubTodoItemDto subTodoItemDto);
}
