namespace UserCrud.Contracts.User;

public record UpdateUserRequest(
    Guid Id,
    string Username,
    string FirstName,
    string LastName,
    DateTime DateCreated);
