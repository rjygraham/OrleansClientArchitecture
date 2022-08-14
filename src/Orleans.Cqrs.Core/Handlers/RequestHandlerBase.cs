using Microsoft.AspNetCore.Http;
using Orleans.Cqrs.Abstractions;

namespace Orleans.Cqrs.Handlers;

public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest>
    where TRequest : IRequest
{
    protected IGrainFactory GrainFactory { get; init; }
    protected IRequestValidator<TRequest>? Validator { get; init; }

    public RequestHandlerBase(IGrainFactory grainFactory, IRequestValidator<TRequest>? validator = null)
    {
        GrainFactory = grainFactory;
        Validator = validator;
    }

    public abstract Task<IResult> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);

    public async virtual Task<IDictionary<string, string[]>> ValidateAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        if (Validator is null)
        {
            return new Dictionary<string, string[]>();
        }

        return await Validator.ValidateRequestAsync(request, cancellationToken);
    }
}
