using Microsoft.AspNetCore.Http;
using Orleans;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Handlers;
using Sample.Profile.Application.Queries.Requests;
using Sample.Profile.Domain;
using Sample.Profile.Models;

namespace Sample.Profile.Application.Queries.Handlers;

internal class GetProfileByIdQueryHandler : ResourceHandlerBase<Guid, GetProfileByIdRequest>
{
	public GetProfileByIdQueryHandler(IGrainFactory grainFactory, IRequestValidator<GetProfileByIdRequest>? validator = null)
		: base(grainFactory, validator)
	{
	}

	public async override Task<IDictionary<string, string[]>> ValidateAsync(GetProfileByIdRequest request, CancellationToken cancellationToken = default)
	{
		return !request.Id.Equals(Guid.Empty)
			 ? new Dictionary<string, string[]>()
			 : new Dictionary<string, string[]> { { "profileId", new[] { "ProfileId has invalid value." } } };
	}

	public async override Task<IResult> ExecuteAsync(GetProfileByIdRequest request, CancellationToken cancellationToken = default)
	{
		var grain = GrainFactory.GetGrain<IProfileGrain>(request.Id);
		var state = await grain.GetState();

		var response = new ProfileResponse(state.GivenName, state.Surname, state.DateOfBirth, state.EmailAddress, state.PhoneNumber, state.AvatarUri);

		return Results.Ok(response);
	}
}
