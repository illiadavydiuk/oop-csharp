namespace lab14.Abstractions;

public interface ISender
{
    Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default);
}