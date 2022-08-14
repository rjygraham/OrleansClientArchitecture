using FluentValidation;
using Orleans.Cqrs.FluentValidation;
using Sample.Profile.Application.Queries.Requests;

namespace Sample.Profile.Application.Queries.Validators;

internal class GetProfileByIdQueryValidator : RequestAbstractValidator<GetProfileByIdRequest>
{
	public GetProfileByIdQueryValidator()
	{
		RuleFor(r => r.Id).NotEqual(Guid.Empty);
	}
}
