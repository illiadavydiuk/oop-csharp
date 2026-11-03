using lab14.Abstractions;
using lab14.tests.TestRequests;

namespace lab14.tests.TestHandlers;

public sealed class SecondUserCreatedHandler
    : INotificationHandler<UserCreatedNotification>
{
    public static List<string> ReceivedUsers { get; } = [];

    public Task Handle(
        UserCreatedNotification notification,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ReceivedUsers.Add($"Second: {notification.UserName}");

        return Task.CompletedTask;
    }
}