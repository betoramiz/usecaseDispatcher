using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public class UseCaseDispatcher : IUseCaseDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<UseCaseDispatcher> _logger;

    public UseCaseDispatcher(
        IServiceProvider serviceProvider,
        ILogger<UseCaseDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        try
        {
            _logger.LogInformation("Dispatching request of type {RequestType}", typeof(TRequest).Name);
            
            var useCase = _serviceProvider.GetRequiredService<IUseCase<TRequest, TResponse>>();
            var result = await useCase.ExecuteAsync(request);
            
            _logger.LogInformation("Successfully executed use case for {RequestType}", typeof(TRequest).Name);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing use case for {RequestType}", typeof(TRequest).Name);
            throw;
        }
    }
}