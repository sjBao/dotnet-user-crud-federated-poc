using UserCrud.Models;

namespace UserCrud.Data;

public static class DbInitializer
{
    public static void Initialize(UserContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Users.Any())
        {
            return;   // DB has been seeded
        }

        var users = new User[]
        {
            User.Create("CarsonAlexander123", "Carson", "Alexander"),
            User.Create("MeredithAlonso123", "Meredith", "Alonso"),
            User.Create("ArturoAnand123", "Arturo", "Anand"),
            User.Create("GytisBarzdukas123", "Gytis", "Barzdukas"),
            User.Create("YanLi123", "Yan", "Li"),
            User.Create("PeggyJustice123", "Peggy", "Justice"),
            User.Create("LauraNorman123", "Laura", "Norman"),
            User.Create("NinoOlivetto123", "Nino", "Olivetto"),
        };
        foreach (User user in users)
        {
            context.Users.Add(user);
        }
        context.SaveChanges();

    }
}

