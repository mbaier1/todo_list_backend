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
    [Route("{todoId}/subTodo")]
    public IActionResult CreateSubTodo([FromRoute] string todoId, [FromBody] SubTodoItemDto subTodoItem)
    {
        _todoDomain.CreateSubTodo(todoId, subTodoItem);
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

    [HttpPut]
    [Route("{todoId}/subTodo/{id}")]
    public IActionResult UpdateSubTodo([FromRoute] string todoId, [FromRoute] string id, [FromBody] SubTodoItemDto subTodoItemDto)
    {
        _todoDomain.UpdateSubTodo(todoId, id, subTodoItemDto);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteTodo([FromBody] TodoItemDto todoItemDto)
    {
        _todoDomain.DeleteTodo(todoItemDto.Id);

        return NoContent();
    }

    [HttpDelete]
    [Route("{todoId}/subTodo/{id}")]
    public IActionResult DeleteSubTodo([FromRoute] string todoId, [FromRoute] string id, [FromBody] SubTodoItemDto subTodoItemDto)
    {
        _todoDomain.DeleteSubTodo(todoId, id, subTodoItemDto);

        return NoContent();
    }
}
