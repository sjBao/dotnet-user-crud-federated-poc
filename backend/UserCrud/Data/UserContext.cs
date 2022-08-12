using Microsoft.EntityFrameworkCore;
using UserCrud.Models;

namespace UserCrud.Data;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public string DbPath { get; set; }

    public UserContext(DbContextOptions<UserContext> options): base(options) { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
