using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class TestsFormEntity
{
    [Fact]
    public void Add_Test()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new LibraryContext(options))
        {
            context.Database.EnsureCreated();
            UserEntity u1 = new UserEntity
            {
                Pseudo = "Blizzard",
                Prenom = "Louis",
                Nom = "Laborie",
                Mail = "he@gmail.com",
                Mdp = "1234",
                Role = "Admin"
            };
            FormEntity f1 = new FormEntity
            {
                Id = 1,
                Theme = "theme",
                DatePublication = "date",
                Link = "link",
                UserEntityPseudo = "Blizzard",
                User = u1
            };
            FormEntity f2 = new FormEntity
            {
                Id = 2,
                Theme = "theme",
                DatePublication = "date",
                Link = "link",
                UserEntityPseudo = "Blizzard",
                User = u1
            };
            FormEntity f3 = new FormEntity
            {
                Id = 3,
                Theme = "theme",
                DatePublication = "date",
                Link = "link",
                UserEntityPseudo = "Blizzard",
                User = u1
            };
            context.UserSet.Add(u1);
            context.FormSet.Add(f1);
            context.FormSet.Add(f2);
            context.FormSet.Add(f3);
            context.SaveChanges();

            Assert.Equal(3, context.FormSet.Count());
            Assert.Equal("Blizzard", context.FormSet.First().UserEntityPseudo);
            connection.Close();
        }
    }

}