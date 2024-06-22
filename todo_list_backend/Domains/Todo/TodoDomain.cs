using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Calculators.Interfaces;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Domains.Todo;

public class TodoDomain(ITodoDueDateCalculator _TodoDueDateCalculator, ITodoMapper _todoMapper, ITodoRepository _todoRepository) : ITodoDomain
{
    public void CreateTodo(TodoItemDto todoItemDto)
    {
        var todoItemModel = _todoMapper.ToTodoItem(todoItemDto);
        _todoRepository.AddTodoItem(todoItemModel);
    }

    public void CreateSubTodo(string todoId, SubTodoItemDto subTodoItem)
    {
        var subTodoItemModel = _todoMapper.ToSubTodoItem(todoId, subTodoItem);
        _todoRepository.AddSubTodoItem(subTodoItemModel);
    }

    public List<TodoItemDto> GetTodos()
    {
        var todoModels = _todoRepository.GetTodoItems();
        var todoItemDtos = new List<TodoItemDto>();
         todoModels.ForEach(todo =>
        {
            todo.TodoIsOverdue = _TodoDueDateCalculator.CalculateDueDateStatus(todo.Deadline);
            todoItemDtos.Add(_todoMapper.ToTodoItemDto(todo));
        });

        return todoItemDtos;
    }

    public void UpdateTodo(TodoItemDto todoItemDto)
    {
        var todoItemModel = _todoMapper.ToTodoItem(todoItemDto);
        _todoRepository.UpdateTodoItem(todoItemModel);
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
