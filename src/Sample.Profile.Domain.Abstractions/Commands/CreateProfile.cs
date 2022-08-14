using Orleans;

namespace Sample.Profile.Domain.Commands;

[GenerateSerializer]
public record CreateProfile
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
}
