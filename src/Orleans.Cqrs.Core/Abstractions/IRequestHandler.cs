using Microsoft.AspNetCore.Http;

namespace Orleans.Cqrs.Abstractions;

public interface IRequestHandler<TRequest>
    where TRequest : IRequest
{
	Task<IDictionary<string, string[]>> ValidateAsync(TRequest request, CancellationToken cancellationToken = default);

	Task<IResult> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
}
