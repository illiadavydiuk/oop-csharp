using lab14.Abstractions;

namespace lab14.tests.TestRequests;

public sealed record UnregisteredQuery : IRequest<string>;