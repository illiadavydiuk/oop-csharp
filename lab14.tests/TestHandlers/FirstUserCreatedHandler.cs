using lab14.Abstractions;
using lab14.tests.TestRequests;

namespace lab14.tests.TestHandlers;

public sealed class FirstUserCreatedHandler
    : INotificationHandler<UserCreatedNotification>
{
    public static List<string> ReceivedUsers { get; } = [];

    public Task Handle(
        UserCreatedNotification notification,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ReceivedUsers.Add($"First: {notification.UserName}");

        return Task.CompletedTask;
    }
}