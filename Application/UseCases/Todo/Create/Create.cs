using Application.Interfaces;
using Domain.Common;
using Domain.Todo;
using Rebus.Bus;

namespace Application.UseCases.Todo.Create;

public class Create: IUseCase<TodoRequest, TodoResponse>
{
    private readonly IBus _bus;
    public Create(IBus bus)
    {
        _bus = bus;
    }

    public async Task<TodoResponse> ExecuteAsync(TodoRequest request)
    {
        var newTodo = Domain.Todo.Todo.Create(request.Name);
        
        // save to database first
        await _bus.Publish(new CreatedEvent(newTodo.Name));
        
        return await Task.FromResult(new TodoResponse(newTodo.Id.ToString()));
    }
}