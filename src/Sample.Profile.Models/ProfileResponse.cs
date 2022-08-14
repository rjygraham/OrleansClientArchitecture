namespace Sample.Profile.Models;

public record ProfileResponse(string GivenName, string Surname, DateTimeOffset DateOfBirth, string EmailAddress, string PhoneNumber, string? AvatarUri);

