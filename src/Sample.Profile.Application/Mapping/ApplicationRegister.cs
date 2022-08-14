using Mapster;
using Sample.Profile.Domain.Commands;
using Sample.Profile.Domain.Events;
using Sample.Profile.Models;

namespace Sample.Profile.Application.Mapping;

internal class ApplicationRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProfile, ProfileCreated>().Compile();
        config.NewConfig<Models.CreateProfileRequest, CreateProfile>().Compile();
    }
}
