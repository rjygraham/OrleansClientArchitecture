using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Core.Abstractions;

namespace Orleans.Cqrs.Core;

internal class RequestProcessor<TRequest>
    where TRequest : IRequest
{ 
    private readonly IServiceProvider services;

    public RequestProcessor(IServiceProvider services)
    {
        this.services = services;
    }

    internal async Task<IResult> ExecuteRequestAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        var handler = services.GetService<IRequestHandler<TRequest>>();

		var errors = await handler.ValidateAsync(request, cancellationToken);
		if (errors.Count > 0)
		{
			return Results.ValidationProblem(errors);
		}

		try
		{
			(handler as IParametersHandler<TRequest>)?.Map(request, cancellationToken);
			return await handler.ExecuteAsync(request, cancellationToken);
		}
		catch (Exception)
		{
			return Results.StatusCode(500);
		}
    }
}
