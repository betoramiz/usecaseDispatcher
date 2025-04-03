using System.Reflection;
using Application.Interfaces;
using Application.UseCases.Todo.Create;
using Application.UseCases.Todo.List;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.Scan(scan => scan
        .FromAssemblies(Assembly.Load("Application"))
        .AddClasses(classes => classes.AssignableTo(typeof(IUseCase<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
    );

    builder.Services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();
}

var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}


