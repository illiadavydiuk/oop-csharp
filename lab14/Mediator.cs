using lab14.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace lab14;

public sealed class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        cancellationToken.ThrowIfCancellationRequested();

        Type requestType = request.GetType();

        Type handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(requestType, typeof(TResponse));

        object handler;

        try
        {
            handler = serviceProvider.GetRequiredService(handlerType);
        }
        catch (InvalidOperationException exception)
        {
            throw new InvalidOperationException(
                $"Для запиту '{requestType.Name}' не зареєстровано обробник '{handlerType.Name}'.",
                exception);
        }

        var handleMethod = handlerType.GetMethod(
            nameof(IRequestHandler<IRequest<TResponse>, TResponse>.Handle))
            ?? throw new InvalidOperationException(
                "Не вдалося знайти метод Handle.");

        var task = handleMethod.Invoke(
            handler,
            [request, cancellationToken]) as Task<TResponse>
            ?? throw new InvalidOperationException(
                "Обробник повернув некоректний результат.");

        return await task.ConfigureAwait(false);
    }

    public async Task Publish(
        INotification notification,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(notification);
        cancellationToken.ThrowIfCancellationRequested();

        Type notificationType = notification.GetType();

        Type handlerType = typeof(INotificationHandler<>)
            .MakeGenericType(notificationType);

        var handlers = serviceProvider.GetServices(handlerType);

        var handleMethod = handlerType.GetMethod(
            nameof(INotificationHandler<INotification>.Handle))
            ?? throw new InvalidOperationException(
                "Не вдалося знайти метод Handle.");

        foreach (object handler in handlers)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var task = handleMethod.Invoke(
                handler,
                [notification, cancellationToken]) as Task
                ?? throw new InvalidOperationException(
                    "Обробник повернув некоректний результат.");

            await task.ConfigureAwait(false);
        }
    }
}