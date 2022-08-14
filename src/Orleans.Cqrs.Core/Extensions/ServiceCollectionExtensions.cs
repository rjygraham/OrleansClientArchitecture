using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Core;

namespace Orleans.Cqrs.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddOrleansRequests(this IServiceCollection services, params Assembly[] assemblies)
	{
		return services
			.AddScoped(typeof(RequestProcessor<>));
	}

	public static IServiceCollection AddHandler<TRequest, THandler>(this IServiceCollection services)
		where TRequest : IRequest
		where THandler : class, IRequestHandler<TRequest>
	{
		return services.AddScoped<IRequestHandler<TRequest>, THandler>();
	}

	public static IServiceCollection AddHandler<TRequest, THandler, TValidator>(this IServiceCollection services)
		where TRequest : IRequest
		where THandler : class, IRequestHandler<TRequest>
		where TValidator: class, IRequestValidator<TRequest>
	{
		return services
			.AddScoped<IRequestHandler<TRequest>, THandler>()
			.AddScoped<IRequestValidator<TRequest>, TValidator>();
	}
}
