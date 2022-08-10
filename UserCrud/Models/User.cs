namespace UserCrud.Models;

public class User
{
    public Guid Id { get; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateCreated { get; }


    private User(
        Guid id, 
        string username, 
        string firstName, 
        string lastName, 
        DateTime dateCreated)
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        DateCreated = dateCreated;
    }

    public static User Create(
        string username, 
        string firstName, 
        string lastName)
    {
        return new User(
            Guid.NewGuid(), 
            username, 
            firstName, 
            lastName, 
            DateTime.UtcNow);
    }
}
