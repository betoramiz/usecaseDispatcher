using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class UseCaseDispatcher : IUseCaseDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public UseCaseDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        var useCase = _serviceProvider.GetService<IUseCase<TRequest, TResponse>>();

        if (useCase == null)
        {
            throw new ApplicationException($"No use case registered for {typeof(TRequest).Name}");
        }

        try
        {
            var result = await useCase.ExecuteAsync(request);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}