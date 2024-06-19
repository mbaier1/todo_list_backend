using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;
using todo_list_backend.Repositories.Interfaces;

namespace todo_list_backend.Domains.Todo;

public class TodoDomain(ITodoItemDtoToTodoItemMapper _todoItemDtoToTodoItemMapper, ITodoItemModelToTodoItemDto _todoItemModelToTodoItemDto, ITodoRepository _todoRepository) : ITodoDomain
{
    public List<TodoItemDto> GetTodos()
    {
        var todoModels = _todoRepository.GetTodos();
        var todoItemDtos = new List<TodoItemDto>();
         todoModels.ForEach(todo =>
        {
            todoItemDtos.Add(_todoItemModelToTodoItemDto.Map(todo));
        });

        return todoItemDtos;
    }

    public void CreateTodo(TodoItemDto todoItemDto)
    {
        var todoItemModel = _todoItemDtoToTodoItemMapper.Map(todoItemDto);
        _todoRepository.AddTodoItem(todoItemModel);
    }

}
