using Application.Interfaces;

namespace Application.UseCases.Todo.List;

public record TodoListRequest() : IRequest<ICollection<TodoListResponse>>;