using Application.Interfaces;
using Application.UseCases.Todo.Create;
using Application.UseCases.Todo.List;
using Microsoft.AspNetCore.Mvc;

namespace Api.Todos
{
    [Route("api/todo")]
    [ApiController]
    public class Todo : ControllerBase
    {
        private readonly IUseCaseDispatcher _useCaseDispatcher;
        public Todo(IUseCaseDispatcher useCaseDispatcher) => _useCaseDispatcher = useCaseDispatcher;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _useCaseDispatcher.DispatchAsync<TodoListRequest, ICollection<TodoListResponse>>(new TodoListRequest());
            return Ok(results);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(TodoRequest request)
        {
            var result = await _useCaseDispatcher.DispatchAsync<TodoRequest, TodoResponse>(request);
            return Ok(result);
        }
    }
}
