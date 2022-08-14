using FluentValidation;
using Orleans.Cqrs.Abstractions;

namespace Orleans.Cqrs.FluentValidation;

public abstract class RequestAbstractValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
{
	private static IDictionary<string, string[]> NoErrors = new Dictionary<string, string[]>();

	public async Task<IDictionary<string, string[]>> ValidateRequestAsync(TRequest request, CancellationToken cancellationToken = default)
	{
		var validationResult = Validate(request);

		return validationResult.IsValid
			? NoErrors
			: validationResult.ToErrorDictionary();
	}
}
