using Orleans;
using Sample.Profile.Domain.Commands;

namespace Sample.Profile.Domain;

public interface IProfileGrain : IGrainWithGuidKey
{
    ValueTask<ProfileState> GetState();
    Task HandleAsync(CreateProfile message);
}
