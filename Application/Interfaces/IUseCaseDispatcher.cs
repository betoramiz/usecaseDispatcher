namespace Application.Interfaces;

public interface IUseCaseDispatcher
{
    Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request) 
        where TRequest : IRequest<TResponse>;
}