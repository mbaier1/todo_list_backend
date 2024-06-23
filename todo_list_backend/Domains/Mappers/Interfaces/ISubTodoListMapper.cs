using todo_list_backend.Data.Models;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers.Interfaces;

public interface ISubTodoListMapper
{
    List<SubTodoItemDto> ToSubTodoItemDtos(List<SubTodoItem> subTodoItems);
}
