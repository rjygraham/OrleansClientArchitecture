using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Orleans.Cqrs.Abstractions;
using Orleans.Cqrs.Core;

namespace Orleans.Cqrs.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseDefaultPipeline(this WebApplication app)
    {
        app.UseAuthentication()
            .UseAuthorization()
            .UseExceptionHandler("/error")
            .UseResponseCompression();

        return app;
    }

    public static RouteHandlerBuilder MapCommandRequest<TRequest>(this WebApplication app, string template)
        where TRequest : IRequest
    {
        return app.MapPost(template, async (RequestProcessor<TRequest> invoker, [AsParameters] TRequest request) => await invoker.ExecuteRequestAsync(request));
    }

    public static RouteHandlerBuilder MapQueryRequest<TRequest>(this WebApplication app, string template)
        where TRequest : IRequest
    {
        return app.MapGet(template, async (RequestProcessor<TRequest> invoker, [AsParameters] TRequest request) => await invoker.ExecuteRequestAsync(request));
    }
}
