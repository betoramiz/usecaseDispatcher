using Application.Interfaces;

namespace Application.UseCases.Todo.Create;

public class Create: IUseCase<TodoRequest, TodoResponse>
{
    public async Task<TodoResponse> ExecuteAsync(TodoRequest request)
    {
        var newTodo = Domain.Todo.Create(request.Name);
        
        return await Task.FromResult(new TodoResponse(newTodo.Id.ToString()));
    }
}