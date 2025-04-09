using System.Reflection;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddUseCases();
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(classes => classes.AssignableTo(typeof(IUseCase<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}