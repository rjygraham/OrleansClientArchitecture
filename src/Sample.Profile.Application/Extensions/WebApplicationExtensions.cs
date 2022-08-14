using Microsoft.AspNetCore.Builder;
using Orleans.Cqrs.Extensions;
using Sample.Profile.Application.Commands.Requests;
using Sample.Profile.Application.Queries.Requests;

namespace Sample.Profile.Application.Extensions;

public static class WebApplicationExtensions
{
	public static WebApplication MapOrleansHandlers(this WebApplication app)
	{
		app.MapCommandRequest<CreateProfileParametersRequest>("/profile");
		app.MapQueryRequest<GetProfileByIdRequest>("/profile/{id}");
		return app;
	}
}
