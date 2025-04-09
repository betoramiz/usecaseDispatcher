using System.Reflection;
using Application.Interfaces;
using Application.UseCases.Todo.Events;
using Domain.Common;
using Domain.Todo;
using Infrastructure.Events;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        const string inputQueueName = "domainEvents";

        services.AddScoped<IEventPublisher, RebusEventPublisher>();
        services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();
        
        return
            services
                .AddRebusWithInMemoryTransport(inputQueueName)
                .AddEventHandlers();
    }

    private static IServiceCollection AddRebusWithInMemoryTransport(this IServiceCollection services, string inputQueueName)
    {
        services.AddRebus(configure => configure
            .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), inputQueueName))
            .Options(o => o.SetNumberOfWorkers(1))
        );

        return services;
    }
    
    private static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(Assembly.Load("Application"))
            .AddClasses(classes => classes.AssignableTo(typeof(IHandleMessages<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}