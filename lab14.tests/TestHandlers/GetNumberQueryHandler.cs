using lab14.Abstractions;
using lab14.tests.TestRequests;

namespace lab14.tests.TestHandlers;

public sealed class GetNumberQueryHandler
    : IRequestHandler<GetNumberQuery, int>
{
    public Task<int> Handle(
        GetNumberQuery request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(request.Number);
    }
}