using API.Requests;
using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetTodoById;
using Application.Todos.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetTodosQuery());
            return Ok(result);

        }



        [HttpGet("{todoId:Guid}", Name = "GetTodoById")]
        public async Task<IActionResult> GetById(Guid todoId)
        {
            var result = await mediator.Send(new GetTodoByIdQuery(todoId));
            return result is null ? NotFound() : Ok(result);

        }


        [HttpPost]

        public async Task<IActionResult> AddTodo(CreateTodoRequest request)
        {
            var command = new CreateTodoCommand(request.Title);
            var todoId = await mediator.Send(command);
            return CreatedAtRoute("GetTodoById", new { todoId }, null);
        }

        [HttpPut("{todoId:Guid}")]

        public async Task<IActionResult> UpdateTodo(Guid todoId, UpdateTodoRequest request)
        {
            var command = new UpdateTodoCommand(todoId, request.Title, request.Completed);
            await mediator.Send(command);
            return NoContent();

        }

        [HttpDelete("{todoId:Guid}")]

        public async Task<IActionResult> DeleteTodo(Guid todoId)
        {
            var command = new DeleteTodoCommand(todoId);
            await mediator.Send(command);
            return NoContent();

        }
    }
}
