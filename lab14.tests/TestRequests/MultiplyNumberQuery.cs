using lab14.Abstractions;

namespace lab14.tests.TestRequests;

public sealed record MultiplyNumberQuery(
    int Number,
    int Multiplier) : IRequest<int>;