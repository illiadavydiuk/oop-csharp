using System.Reflection;
using lab14.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace lab14;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assemblies);

        if (assemblies.Length == 0)
        {
            throw new ArgumentException(
                "Потрібно передати щонайменше одну збірку для пошуку обробників.",
                nameof(assemblies));
        }

        services.AddTransient<Mediator>();

        services.AddTransient<IMediator>(
            provider => provider.GetRequiredService<Mediator>());

        services.AddTransient<ISender>(
            provider => provider.GetRequiredService<Mediator>());

        services.AddTransient<IPublisher>(
            provider => provider.GetRequiredService<Mediator>());

        var handlerInterfaces = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>)
        };

        foreach (Type implementationType in assemblies
                     .Distinct()
                     .SelectMany(GetLoadableTypes)
                     .Where(type => type is { IsClass: true, IsAbstract: false }))
        {
            Type[] implementedHandlerInterfaces = implementationType
                .GetInterfaces()
                .Where(interfaceType =>
                    interfaceType.IsGenericType &&
                    handlerInterfaces.Contains(
                        interfaceType.GetGenericTypeDefinition()))
                .ToArray();

            foreach (Type handlerInterface in implementedHandlerInterfaces)
            {
                services.AddTransient(
                    handlerInterface,
                    implementationType);
            }
        }

        return services;
    }

    public static IServiceCollection AddMediatorFromAssemblyContaining<T>(
        this IServiceCollection services)
    {
        return services.AddMediator(typeof(T).Assembly);
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException exception)
        {
            return exception.Types.OfType<Type>();
        }
    }
}