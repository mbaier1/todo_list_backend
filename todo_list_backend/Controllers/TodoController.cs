using Microsoft.AspNetCore.Mvc;
using todo_list_backend.Domains.Todo.Interfaces;
using todo_list_backend.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_list_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(ICreateTodo _createDtoDomain) : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] TodoItemDto todoItemDto)
    {
        Console.WriteLine(todoItemDto);

        return Created();
    }
}
