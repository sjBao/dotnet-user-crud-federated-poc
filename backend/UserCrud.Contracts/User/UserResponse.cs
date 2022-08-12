namespace UserCrud.Contracts.User;

public record UserResponse(
    Guid Id,
    string Username,
    string FirstName,
    string LastName,
    DateTime DateCreated);
