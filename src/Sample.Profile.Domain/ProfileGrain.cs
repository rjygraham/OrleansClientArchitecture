using Mapster;
using Orleans.EventSourcing;
using Orleans.Providers;
using Sample.Profile.Domain.Commands;
using Sample.Profile.Domain.Events;

namespace Sample.Profile.Domain;

[LogConsistencyProvider(ProviderName = "LogStorage")]
public class ProfileGrain : JournaledGrain<ProfileState>, IProfileGrain
{
    public ValueTask<ProfileState> GetState()
    {
        return ValueTask.FromResult(State);
    }

    public async Task HandleAsync(CreateProfile command)
    {
        if (string.IsNullOrEmpty(State.GivenName))
        {
            var @event = command.Adapt<ProfileCreated>();

            RaiseEvent(@event);

            await ConfirmEvents();
        }
    }
}
