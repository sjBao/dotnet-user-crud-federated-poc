namespace UserCrud.Contracts.User;

public record UpdateUserRequest(
    string Username,
    string FirstName,
    string LastName);
