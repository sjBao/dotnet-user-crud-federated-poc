using Microsoft.EntityFrameworkCore;
using UserCrud.Models;
namespace UserCrud.Models;



public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public string DbPath { get; set; }

    public UserContext() { 
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "users.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}




public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateCreated { get; set; }


    public User(
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
