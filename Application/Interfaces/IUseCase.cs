namespace Application.Interfaces;

public interface IRequest<out TResponse> { }

public interface IUseCase<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> ExecuteAsync(TRequest request);
}