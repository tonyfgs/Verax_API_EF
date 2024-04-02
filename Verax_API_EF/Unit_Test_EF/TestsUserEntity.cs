using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class TestsUserEntity
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
                Pseudo = "Tofgasy", Prenom = "Tony", Nom = "Fages", Mail = "he@gmail.com", Mdp = "1234", Role = "Admin"
            };
            UserEntity u2 = new UserEntity
            {
                Pseudo = "Blizzard", Prenom = "Louis", Nom = "Laborie", Mail = "he@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            UserEntity u3 = new UserEntity
            {
                Pseudo = "TomS", Prenom = "Tom", Nom = "Smith", Mail = "TomS@gmail.com", Mdp = "1234", Role = "User"
            };
            UserEntity u4 = new UserEntity
            {
                Pseudo = "Siwa", Prenom = "Jean", Nom = "Marcillac", Mail = "occitan@gmail.com", Mdp = "1234",
                Role = "Amin"
            };
            UserEntity u5 = new UserEntity
            {
                Pseudo = "Sha", Prenom = "Shana", Nom = "Cascarra", Mail = "shacas@gmail.com", Mdp = "1234",
                Role = "Modérator"
            };
            UserEntity u6 = new UserEntity
            {
                Pseudo = "NoaSil", Prenom = "Noa", Nom = "Sillard", Mail = "noaSillar@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            context.UserSet.Add(u1);
            context.UserSet.Add(u2);
            context.UserSet.Add(u3);
            context.UserSet.Add(u4);
            context.UserSet.Add(u5);
            context.UserSet.Add(u6);
            context.SaveChanges();

            Assert.Equal(6, context.UserSet.Count());
            Assert.Equal("Blizzard", context.UserSet.First().Pseudo);
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
                Pseudo = "Tofgasy", Prenom = "Tony", Nom = "Fages", Mail = "he@gmail.com", Mdp = "1234", Role = "Admin"
            };
            UserEntity u2 = new UserEntity
            {
                Pseudo = "Blizzard", Prenom = "Louis", Nom = "Laborie", Mail = "he@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            UserEntity u3 = new UserEntity
            {
                Pseudo = "TomS", Prenom = "Tom", Nom = "Smith", Mail = "TomS@gmail.com", Mdp = "1234", Role = "User"
            };
            UserEntity u4 = new UserEntity
            {
                Pseudo = "Siwa", Prenom = "Jean", Nom = "Marcillac", Mail = "occitan@gmail.com", Mdp = "1234",
                Role = "Amin"
            };
            UserEntity u5 = new UserEntity
            {
                Pseudo = "Sha", Prenom = "Shana", Nom = "Cascarra", Mail = "shacas@gmail.com", Mdp = "1234",
                Role = "Modérator"
            };
            UserEntity u6 = new UserEntity
            {
                Pseudo = "NoaSil", Prenom = "Noa", Nom = "Sillard", Mail = "noaSillar@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            context.UserSet.Add(u1);
            context.UserSet.Add(u2);
            context.UserSet.Add(u3);
            context.UserSet.Add(u4);
            context.UserSet.Add(u5);
            context.UserSet.Add(u6);
            context.SaveChanges();
            
            var user = context.UserSet.First(u => u.Pseudo.Equals("Tofgasy"));
            user.Prenom = "Tof";
            context.SaveChanges();
            string persRemove = "Tony";
            string persNew = "Tof";
            Assert.Equal(1, context.UserSet.Count(u => u.Prenom.Equals(persNew)));
            Assert.Equal(0, context.UserSet.Count(u => u.Prenom.Equals(persRemove)));
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
                Pseudo = "Tofgasy", Prenom = "Tony", Nom = "Fages", Mail = "he@gmail.com", Mdp = "1234", Role = "Admin"
            };
            UserEntity u2 = new UserEntity
            {
                Pseudo = "Blizzard", Prenom = "Louis", Nom = "Laborie", Mail = "he@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            UserEntity u3 = new UserEntity
            {
                Pseudo = "TomS", Prenom = "Tom", Nom = "Smith", Mail = "TomS@gmail.com", Mdp = "1234", Role = "User"
            };
            UserEntity u4 = new UserEntity
            {
                Pseudo = "Siwa", Prenom = "Jean", Nom = "Marcillac", Mail = "occitan@gmail.com", Mdp = "1234",
                Role = "Amin"
            };
            UserEntity u5 = new UserEntity
            {
                Pseudo = "Sha", Prenom = "Shana", Nom = "Cascarra", Mail = "shacas@gmail.com", Mdp = "1234",
                Role = "Modérator"
            };
            UserEntity u6 = new UserEntity
            {
                Pseudo = "NoaSil", Prenom = "Noa", Nom = "Sillard", Mail = "noaSillar@gmail.com", Mdp = "1234",
                Role = "Admin"
            };
            context.UserSet.Add(u1);
            context.UserSet.Add(u2);
            context.UserSet.Add(u3);
            context.UserSet.Add(u4);
            context.UserSet.Add(u5);
            context.UserSet.Add(u6);
            context.SaveChanges();
            
            Assert.Equal(6, context.UserSet.Count());
            var user = context.UserSet.First(u => u.Pseudo.Equals("Tofgasy"));
            context.Remove(user);
            context.SaveChanges();
            Assert.Equal(5, context.UserSet.Count());
            Assert.Equal(0, context.UserSet.Count(u => u.Pseudo.Equals("Tofgasy")));
            connection.Close();
        }
    }
}