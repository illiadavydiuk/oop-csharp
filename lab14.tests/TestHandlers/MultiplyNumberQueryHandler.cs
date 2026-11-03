using lab14.Abstractions;
using lab14.tests.TestRequests;

namespace lab14.tests.TestHandlers;

public sealed class MultiplyNumberQueryHandler
    : IRequestHandler<MultiplyNumberQuery, int>
{
    public Task<int> Handle(
        MultiplyNumberQuery request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(
            request.Number * request.Multiplier);
    }
}