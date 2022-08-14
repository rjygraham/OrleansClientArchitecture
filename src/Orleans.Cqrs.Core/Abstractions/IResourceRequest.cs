namespace Orleans.Cqrs.Abstractions;

public interface IResourceRequest<TResourceId> : IRequest
{
    TResourceId Id { get; }
}
