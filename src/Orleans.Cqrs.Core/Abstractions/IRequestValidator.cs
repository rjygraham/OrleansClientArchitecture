namespace Orleans.Cqrs.Abstractions;

public interface IRequestValidator<TRequest>
{
    Task<IDictionary<string, string[]>> ValidateRequestAsync(TRequest request, CancellationToken cancellationToken = default);
}
