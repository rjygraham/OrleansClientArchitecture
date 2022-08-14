namespace Orleans.Cqrs.Abstractions;

public interface IParametersRequest<TParameters> : IRequest
{
	TParameters Parameters { get; }
}
