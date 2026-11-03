using lab14.Abstractions;
using lab14.tests.TestHandlers;
using lab14.tests.TestRequests;
using Microsoft.Extensions.DependencyInjection;

namespace lab14.tests;

[TestFixture]
public sealed class MediatorTests
{
    private ServiceProvider _serviceProvider = null!;
    private IMediator _mediator = null!;

    [SetUp]
    public void SetUp()
    {
        FirstUserCreatedHandler.ReceivedUsers.Clear();
        SecondUserCreatedHandler.ReceivedUsers.Clear();

        var services = new ServiceCollection();

        services.AddMediator(
            typeof(GetNumberQueryHandler).Assembly);

        _serviceProvider = services.BuildServiceProvider();

        _mediator = _serviceProvider
            .GetRequiredService<IMediator>();
    }

    [TearDown]
    public void TearDown()
    {
        _serviceProvider.Dispose();
    }

    [Test]
    public async Task Send_ReturnsExpectedResponse()
    {
        var response = await _mediator.Send(
            new GetNumberQuery(42));

        Assert.That(response, Is.EqualTo(42));
    }

    [Test]
    public async Task Send_UsesHandlerForCorrectRequestType()
    {
        var response = await _mediator.Send(
            new MultiplyNumberQuery(6, 7));

        Assert.That(response, Is.EqualTo(42));
    }

    [Test]
    public void Send_ThrowsWhenHandlerIsNotRegistered()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await _mediator.Send(
                new UnregisteredQuery()));

        Assert.That(
            exception!.Message,
            Does.Contain("не зареєстровано обробник"));
    }

    [Test]
    public void Send_ThrowsWhenCancellationTokenIsCancelled()
    {
        using var cancellationTokenSource =
            new CancellationTokenSource();

        cancellationTokenSource.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await _mediator.Send(
                new GetNumberQuery(10),
                cancellationTokenSource.Token));
    }

    [Test]
    public async Task Publish_CallsAllRegisteredHandlers()
    {
        await _mediator.Publish(
            new UserCreatedNotification("Clark"));

        Assert.That(
            FirstUserCreatedHandler.ReceivedUsers,
            Is.EqualTo(new[] { "First: Clark" }));

        Assert.That(
            SecondUserCreatedHandler.ReceivedUsers,
            Is.EqualTo(new[] { "Second: Clark" }));
    }

    [Test]
    public void Publish_ThrowsWhenCancellationTokenIsCancelled()
    {
        using var cancellationTokenSource =
            new CancellationTokenSource();

        cancellationTokenSource.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await _mediator.Publish(
                new UserCreatedNotification("Clark"),
                cancellationTokenSource.Token));
    }

    [Test]
    public void MediatorInterfacesAreRegisteredAsTransient()
    {
        var firstMediator =
            _serviceProvider.GetRequiredService<IMediator>();

        var secondMediator =
            _serviceProvider.GetRequiredService<IMediator>();

        var firstSender =
            _serviceProvider.GetRequiredService<ISender>();

        var secondSender =
            _serviceProvider.GetRequiredService<ISender>();

        var firstPublisher =
            _serviceProvider.GetRequiredService<IPublisher>();

        var secondPublisher =
            _serviceProvider.GetRequiredService<IPublisher>();

        Assert.That(
            firstMediator,
            Is.Not.SameAs(secondMediator));

        Assert.That(
            firstSender,
            Is.Not.SameAs(secondSender));

        Assert.That(
            firstPublisher,
            Is.Not.SameAs(secondPublisher));
    }

    [Test]
    public void RequestHandlersAreRegisteredAsTransient()
    {
        var firstHandler =
            _serviceProvider.GetRequiredService<
                IRequestHandler<GetNumberQuery, int>>();

        var secondHandler =
            _serviceProvider.GetRequiredService<
                IRequestHandler<GetNumberQuery, int>>();

        Assert.That(
            firstHandler,
            Is.Not.SameAs(secondHandler));
    }
}