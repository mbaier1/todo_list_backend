using Microsoft.AspNetCore.Mvc;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(ITodoDomain _dtoDomain) : ControllerBase
{
    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(_dtoDomain.GetTodos());
    }

    [HttpPost]
    public IActionResult CreateTodo([FromBody] TodoItemDto todoItemDto)
    {
        _dtoDomain.CreateTodo(todoItemDto);

        return Created();
    }

    [HttpDelete]
    public IActionResult DeleteTodo([FromBody] TodoItemDto todoItemDto)
    {
        _dtoDomain.DeleteTodo(todoItemDto.Id);

        return NoContent();
    }
}
