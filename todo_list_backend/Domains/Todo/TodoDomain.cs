using todo_list_backend.Domains.Calculators.Interfaces;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Domains.Todo;

public class TodoDomain(ITodoDueDateCalculator _TodoDueDateCalculator, ITodoItemDtoToTodoItemMapper _todoItemDtoToTodoItemMapper, ITodoItemModelToTodoItemDto _todoItemModelToTodoItemDto, ITodoRepository _todoRepository) : ITodoDomain
{
    public List<TodoItemDto> GetTodos()
    {
        var todoModels = _todoRepository.GetTodoItems();
        var todoItemDtos = new List<TodoItemDto>();
         todoModels.ForEach(todo =>
        {
            todoItemDtos.Add(_todoItemModelToTodoItemDto.Map(todo));
        });

        return todoItemDtos;
    }

    public void CreateTodo(TodoItemDto todoItemDto)
    {
        todoItemDto.TodoIsOverdue = _TodoDueDateCalculator.CalculateDueDateStatus(todoItemDto.Deadline);
        var todoItemModel = _todoItemDtoToTodoItemMapper.Map(todoItemDto);
        _todoRepository.AddTodoItem(todoItemModel);
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
            throw new Exception($"unable to delete record due to the following reason(s): {e.Message}");
        }
    }
}
