namespace UserCrud.Contracts.User;

public record CreateUserRequest(
    string Username,
    string FirstName,
    string LastName,
    DateTime DateCreated);


