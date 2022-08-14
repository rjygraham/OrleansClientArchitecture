using Microsoft.AspNetCore.Http;
using Orleans;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Handlers;
using Sample.Profile.Application.Commands.Requests;
using Sample.Profile.Domain;
using Sample.Profile.Domain.Commands;
using Sample.Profile.Models;

namespace Sample.Profile.Application.Commands.Handlers;

public class CreateProfileCommandHandler : ParametersHandlerBase<CreateProfileRequest, CreateProfileParametersRequest, CreateProfile>
{
	public CreateProfileCommandHandler(IGrainFactory grainFactory, IRequestMapper<CreateProfileRequest, CreateProfile> mapper, IRequestValidator<CreateProfileParametersRequest>? validator = null)
		: base(grainFactory, mapper, validator)
	{
	}

	public override async Task<IResult> ExecuteAsync(CreateProfileParametersRequest request, CancellationToken cancellationToken = default)
	{
		var profileId = Guid.NewGuid();
		var profile = GrainFactory.GetGrain<IProfileGrain>(profileId);

		await profile.HandleAsync(DomainObject!);

		return Results.Created($"/profile/{profileId}", null);
	}
}
