namespace Sample.Profile.Models;

public record CreateProfileRequest(string GivenName, string Surname, DateTimeOffset DateOfBirth, string EmailAddress, string PhoneNumber, string? AvatarUri);
