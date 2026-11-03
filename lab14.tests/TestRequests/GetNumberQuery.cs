using lab14.Abstractions;

namespace lab14.tests.TestRequests;

public sealed record GetNumberQuery(int Number) : IRequest<int>;