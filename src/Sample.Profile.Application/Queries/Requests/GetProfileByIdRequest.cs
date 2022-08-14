using Orleans.Cqrs.Abstractions;

namespace Sample.Profile.Application.Queries.Requests;

public class GetProfileByIdRequest : IResourceRequest<Guid>
{
	public Guid Id { get; set; }
}
