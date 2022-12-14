using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Core.Abstractions;

namespace Orleans.Cqrs.Handlers;

public abstract class ParametersHandlerBase<TParameters, TRequest, TDomain> : RequestHandlerBase<TRequest>, IParametersHandler<TRequest>
	where TRequest : IParametersRequest<TParameters> 
{
	protected TDomain? DomainObject { get; private set; }
	protected IRequestMapper<TParameters, TDomain>? Mapper { get; private set; }

	protected ParametersHandlerBase(IGrainFactory grainFactory, IRequestMapper<TParameters, TDomain>? mapper = null, IRequestValidator<TRequest>? validator = null)
		: base(grainFactory, validator)
	{
		Mapper = mapper;
	}

	public virtual void Map(TRequest request, CancellationToken cancellationToken = default)
	{
		if (Mapper is null)
		{
			throw new InvalidOperationException($"Either override the {nameof(Map)} method to implement custom mapping or ensure a resolvable instance of {nameof(IRequestMapper<TParameters, TDomain>)} is registered in the container.");
		}

		SetDomainObject(Mapper.MapParameters(request.Parameters));
	}

	protected void SetDomainObject(TDomain domainObject)
	{
		DomainObject = domainObject;
	}
}
