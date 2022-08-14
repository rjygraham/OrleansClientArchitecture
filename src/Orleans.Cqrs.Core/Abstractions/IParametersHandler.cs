namespace Orleans.Cqrs.Core.Abstractions;

public interface IParametersHandler<TRequest>
{
	void Map(TRequest request, CancellationToken cancellationToken = default);
}
