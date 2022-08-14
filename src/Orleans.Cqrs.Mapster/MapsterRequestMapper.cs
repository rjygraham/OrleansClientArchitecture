using Mapster;
using Orleans.Cqrs.Abstractions;

namespace Orleans.Cqrs.Mapster;

public class MapsterRequestMapper<TRequest, TDestination> : IRequestMapper<TRequest, TDestination>
{
    public TDestination MapParameters(TRequest source)
    {
        return source!.Adapt<TDestination>();
    }
}
