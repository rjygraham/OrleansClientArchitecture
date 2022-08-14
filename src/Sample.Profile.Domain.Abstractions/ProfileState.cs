using Orleans;
using Sample.Profile.Domain.Events;

namespace Sample.Profile.Domain;

[GenerateSerializer]
public class ProfileState
{
    [Id(0)]
    public string GivenName { get; set; }

    [Id(1)]
    public string Surname { get; set; }

    [Id(2)]
    public DateTimeOffset DateOfBirth { get; set; }

    [Id(3)]
    public string EmailAddress { get; set; }

    [Id(4)]
    public string PhoneNumber { get; set; }

    [Id(5)]
    public string AvatarUri { get; set; }

    public void Apply(ProfileCreated @event)
    {
        GivenName = @event.GivenName;
        Surname = @event.Surname;
        DateOfBirth = @event.DateOfBirth;
        EmailAddress = @event.EmailAddress;
        PhoneNumber = @event.PhoneNumber;
        AvatarUri = @event.AvatarUri;
    }
}
