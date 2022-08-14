using System.Text.RegularExpressions;
using FluentValidation;

namespace Sample.Profile.Models.Validators;

public partial class CreateProfileRequestValidator : AbstractValidator<CreateProfileRequest>
{
	public CreateProfileRequestValidator()
    {
        RuleFor(r => r.GivenName).NotEmpty();
        RuleFor(r => r.Surname).NotEmpty();
        RuleFor(r => r.DateOfBirth).Must(m => m < DateTimeOffset.UtcNow.Date.AddYears(-13));
        RuleFor(r => r.EmailAddress).EmailAddress();
        RuleFor(r => r.PhoneNumber).Matches(GetPhoneNumberRegex());
    }

	[RegexGenerator("^\\+?[1-9][0-9]{7,14}$", RegexOptions.Compiled)]
	private static partial Regex GetPhoneNumberRegex();
}
