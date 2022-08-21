namespace BuberDinner.Contracts.Authentication;
public record Registerrequest(
string FirstName,
string LastName,
string Email,
string Password
);