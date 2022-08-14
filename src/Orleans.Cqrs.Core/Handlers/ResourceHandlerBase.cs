using Orleans.Cqrs.Abstractions;

namespace Orleans.Cqrs.Handlers;

public abstract class ResourceHandlerBase<TResourceId, TRequest> : RequestHandlerBase<TRequest>, IRequestHandler<TRequest>
	where TRequest : IResourceRequest<TResourceId>
{
	protected ResourceHandlerBase(IGrainFactory grainFactory, IRequestValidator<TRequest>? validator = null)
		: base(grainFactory, validator)
	{
	}
}
