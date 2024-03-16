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

    [Fact]
    public void Modify_Test()
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
                Theme = "theme2",
                DatePublication = "date",
                Link = "link",
                UserEntityPseudo = "Blizzard",
                User = u1
            };
            FormEntity f3 = new FormEntity
            {
                Id = 3,
                Theme = "theme3",
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

            var form = context.FormSet.First(f => f.Id == 1);
            form.Theme = "Politique";
            context.SaveChanges();
            string formRemove = "theme";
            string formNew = "Politique";
            Assert.Equal(1, context.FormSet.Count(f => f.Theme == formNew));
            Assert.Equal(0, context.FormSet.Count(f => f.Theme == formRemove));
            connection.Close();

        }
    }

    [Fact]
    public void Remove_Test()
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
                Theme = "theme2",
                DatePublication = "date",
                Link = "link",
                UserEntityPseudo = "Blizzard",
                User = u1
            };
            FormEntity f3 = new FormEntity
            {
                Id = 3,
                Theme = "theme3",
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
            var form = context.FormSet.First(f => f.Theme == "theme2");
            context.Remove(form);
            context.SaveChanges();
            Assert.Equal(2, context.FormSet.Count());
            Assert.Equal(0, context.FormSet.Count(f => f.Theme == "theme2"));
            connection.Close();
        }
    }
}