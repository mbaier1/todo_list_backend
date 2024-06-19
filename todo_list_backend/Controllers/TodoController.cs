using Microsoft.AspNetCore.Mvc;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
}
