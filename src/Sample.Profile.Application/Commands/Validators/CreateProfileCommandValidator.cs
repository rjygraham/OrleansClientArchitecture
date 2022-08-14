using FluentValidation;
using Orleans.Cqrs.FluentValidation;
using Sample.Profile.Application.Commands.Requests;
using Sample.Profile.Models.Validators;

namespace Sample.Profile.Application.Commands.Validators;

public class CreateProfileCommandValidator : RequestAbstractValidator<CreateProfileParametersRequest>
{
	public CreateProfileCommandValidator()
	{
		RuleFor(r => r.Parameters).SetValidator(new CreateProfileRequestValidator()).OverridePropertyName("");
	}
}
