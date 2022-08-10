namespace UserCrud.Contracts.User;

public record UpsertUserRequest(
    Guid Id,
    string Username,
    string FirstName,
    string LastName,
    DateTime DateCreated);
