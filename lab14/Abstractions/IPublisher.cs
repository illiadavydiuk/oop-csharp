namespace lab14.Abstractions;

public interface IPublisher
{
    Task Publish(
        INotification notification,
        CancellationToken cancellationToken = default
    );
}