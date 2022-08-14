using Sample.Profile.Api.Host;
using Sample.Profile.Application.Extensions;
using Orleans.Cqrs.Extensions;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseOrleans((ctx, siloBuilder) =>
{
    siloBuilder
        .UseLocalhostClustering()
        .AddMemoryGrainStorageAsDefault()
        .AddLogStorageBasedLogConsistencyProvider();
});

builder.Host.ConfigureDefaults(args);
builder.Host.ConfigureServices(WebApplicationStartup.ConfigureServices);


var app = builder.Build();

// Configure default HTTP request pipeline.
app.UseDefaultPipeline();

// Map CQRS Handlers
app.MapOrleansHandlers();

app.Run();
