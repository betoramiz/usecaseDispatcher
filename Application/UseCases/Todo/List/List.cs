using Application.Interfaces;

namespace Application.UseCases.Todo.List;

public class List: IUseCase<TodoListRequest, ICollection<TodoListResponse>>
{
    public async Task<ICollection<TodoListResponse>> ExecuteAsync(TodoListRequest request)
    {
        var todos = new List<TodoListResponse>
        {
            new TodoListResponse(Guid.NewGuid().ToString(), "Todo 1"),
            new TodoListResponse(Guid.NewGuid().ToString(), "Todo 2")
        };

        return await Task.FromResult<ICollection<TodoListResponse>>(todos);
    }
}