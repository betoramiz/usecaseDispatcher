using Application.Interfaces;

namespace Application.UseCases.Todo.Create;

public record TodoRequest(string Name): IRequest<TodoResponse>;