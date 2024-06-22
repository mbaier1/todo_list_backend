using Microsoft.AspNetCore.Mvc;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(ITodoDomain _todoDomain) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateTodo([FromBody] TodoItemDto todoItemDto)
    {
        _todoDomain.CreateTodo(todoItemDto);

        return Created();
    }

    [HttpPost]
    [Route("{id}/subTodo")]
    public IActionResult CreateSubTodo([FromRoute] string id, [FromBody] SubTodoItemDto subTodoItem)
    {
        _todoDomain.CreateSubTodo(id, subTodoItem);
        return Created();
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(_todoDomain.GetTodos());
    }

    [HttpPut]
    public IActionResult UpdateTodo([FromBody] TodoItemDto todoItemDto)
    {
        _todoDomain.UpdateTodo(todoItemDto);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteTodo([FromBody] TodoItemDto todoItemDto)
    {
        _todoDomain.DeleteTodo(todoItemDto.Id);

        return NoContent();
    }
}
