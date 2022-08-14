using FastExpressionCompiler;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Extensions;
using Sample.Profile.Application.Commands.Handlers;
using Sample.Profile.Application.Commands.Requests;
using Sample.Profile.Application.Commands.Validators;
using Sample.Profile.Application.Mapping;
using Sample.Profile.Application.Queries.Handlers;
using Sample.Profile.Application.Queries.Requests;
using Sample.Profile.Application.Queries.Validators;
using Orleans.Cqrs.Mapster;

namespace Sample.Profile.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services, params IRegister[] registers)
	{
		registers = registers?.Length > 0
			? registers.Union(new[] { new ApplicationRegister() }).ToArray()
			: new[] { new ApplicationRegister() };

		TypeAdapterConfig.GlobalSettings.Apply(registers);
		TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

		return services
			.AddOrleansRequests(typeof(CreateProfileCommandHandler).Assembly)
			.AddScoped(typeof(IRequestMapper<,>), typeof(MapsterRequestMapper<,>))
			.AddCommandHandlers()
			.AddQueryHandlers();
	}

	private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
	{
		return services
			.AddHandler<CreateProfileParametersRequest, CreateProfileCommandHandler, CreateProfileCommandValidator>();
	}

	private static IServiceCollection AddQueryHandlers(this IServiceCollection services)
	{
		return services
			.AddHandler<GetProfileByIdRequest, GetProfileByIdQueryHandler, GetProfileByIdQueryValidator>();
	}
}
