using Orleans.Cqrs.Abstractions;
using Sample.Profile.Models;

namespace Sample.Profile.Application.Commands.Requests;

public class CreateProfileParametersRequest : IParametersRequest<CreateProfileRequest>
{
	public CreateProfileRequest Parameters { get; init; }
}
