using todo_list_backend.Domains.Calculators.Interfaces;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.Domains.Validators.Interfaces;
using todo_list_backend.DTOs;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Domains.Todo;

public class TodoDomain(IValidateTodoDtos _validator, ITodoDueDateCalculator _TodoDueDateCalculator, ITodoCompletedStatusCalculator _completedStatusCalculator, ITodoMapper _todoMapper, ITodoRepository _todoRepository) : ITodoDomain
{
    public void CreateTodo(TodoItemDto todoItemDto)
    {
        _validator.IsTodoItemDtoValid(todoItemDto);
        var todoItemModel = _todoMapper.ToTodoItem(todoItemDto);
        _todoRepository.AddTodoItem(todoItemModel);
    }

    public void CreateSubTodo(string todoId, SubTodoItemDto subTodoItem)
    {
        _validator.IsSubTodoItemDtoValid(subTodoItem);
        var subTodoItemModel = _todoMapper.ToSubTodoItem(todoId, subTodoItem);
        _todoRepository.AddSubTodoItem(subTodoItemModel);
    }

    public List<TodoItemDto> GetTodos()
    {
        var todoModels = _todoRepository.GetTodoItems();
        var todoItemDtos = new List<TodoItemDto>();
         todoModels.ForEach(todoItem =>
        {
            todoItem.TodoIsOverdue = _TodoDueDateCalculator.CalculateDueDateStatus(todoItem.Deadline);
            todoItem.TodoIsCompleted = _completedStatusCalculator.CalculateStatus(todoItem);
            todoItemDtos.Add(_todoMapper.ToTodoItemDto(todoItem));
        });

        return todoItemDtos;
    }

    public void UpdateTodo(TodoItemDto todoItemDto)
    {
        var todoItemModel = _todoMapper.ToTodoItem(todoItemDto);
        _todoRepository.UpdateTodoItem(todoItemModel);
    }
    public void UpdateSubTodo(string todoId, string id, SubTodoItemDto subTodoItemDto)
    {
        var subTodoItemModel = _todoMapper.ToSubTodoItem(todoId, subTodoItemDto);
        _todoRepository.UpdateSubTodoItem(subTodoItemModel);
    }

    public void DeleteTodo(string id)
    {
        try
        {
            var guidId = Guid.Parse(id);
            var todoItem = _todoRepository.GetTodoItem(guidId);
            _todoRepository.DeleteTodoItem(todoItem);
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to delete record due to the following reason(s): {e.Message}");
        }
    }

    public void DeleteSubTodo(string todoId, string id, SubTodoItemDto subTodoItemDto)
    {
        try
        {
            var subTodoGuidId = Guid.Parse(id);
            var subTodoItemModel = _todoRepository.GetSubTodoItem(subTodoGuidId);

            _todoRepository.DeleteSubTodoItem(subTodoItemModel);
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to delete record due to the following reason(s): {e.Message}");

        }
    }
}
