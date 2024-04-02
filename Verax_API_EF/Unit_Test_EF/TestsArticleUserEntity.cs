using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestsUnitaires;

public class TestsArticleUserEntity
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
            ArticleEntity a1 = new ArticleEntity {  Title = "Breaking News Elisabeth 2 Died", Description = "The queen of England died today at the age of 95", DatePublished = "2022-02-06", LectureTime = 2, Author = "Tom Smith" };
            ArticleEntity a2 = new ArticleEntity { Title = "The new iPhone 15", Description = "The new iPhone 15 is out and it's the best phone ever", DatePublished = "2022-02-06", LectureTime = 3, Author = "Tom Smith" };
            ArticleEntity a3 = new ArticleEntity { Title = "M&M's new recipe", Description = "M&M's new recipe is out and it's the best chocolate ever", DatePublished = "2022-02-06", LectureTime = 1, Author = "M&M's Red" };

            UserEntity u1 = new UserEntity
            {
                Pseudo = "Blizzard",
                Prenom = "Louis",
                Nom = "Laborie",
                Mail = "he@gmail.com",
                Mdp = "1234",
                Role = "Admin"
            };

            ArticleUserEntity au1 = new ArticleUserEntity
            {
                UserEntityPseudo = "Blizzard",
                ArticleEntityId = 1
            };

            ArticleUserEntity au2 = new ArticleUserEntity
            {
                UserEntityPseudo = "Blizzard",
                ArticleEntityId = 2
            };

            ArticleUserEntity au3 = new ArticleUserEntity
            {
                UserEntityPseudo = "Blizzard",
                ArticleEntityId = 3
            };

            context.ArticleSet.Add(a1);
            context.ArticleSet.Add(a2);
            context.ArticleSet.Add(a3);
            context.UserSet.Add(u1);
            context.ArticleUserSet.Add(au1);
            context.ArticleUserSet.Add(au2);
            context.ArticleUserSet.Add(au3);
            context.SaveChanges();

            Assert.Equal(3, context.ArticleSet.Count());
            Assert.Equal(1, context.ArticleUserSet.First().ArticleEntityId);
            connection.Close();
        }
    }

}