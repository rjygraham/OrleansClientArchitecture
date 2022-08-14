using Sample.Profile.Application.Extensions;

namespace Sample.Profile.Api.Host;

internal static class WebApplicationStartup
{
    internal static void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication();

        services.AddAuthorization()
            .AddResponseCompression()
            .AddApplication();
    }

    //internal static void Configure(WebHostBuilderContext ctx, IApplicationBuilder app)
    //{
    //    app.UseAuthentication()
    //        .UseAuthorization()
    //        .UseExceptionHandler("/error")
    //        .UseResponseCompression();
    //}
}
