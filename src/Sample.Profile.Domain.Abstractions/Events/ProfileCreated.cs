namespace Sample.Profile.Domain.Events;

public class ProfileCreated
{
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string AvatarUri { get; set; }
}
