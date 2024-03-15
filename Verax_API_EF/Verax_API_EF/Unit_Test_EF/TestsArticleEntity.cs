using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestsUnitaires;

public class TestsArticleEntity
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

            context.ArticleSet.Add(a1);
            context.ArticleSet.Add(a2);
            context.ArticleSet.Add(a3);

            context.SaveChanges();

            Assert.Equal(3, context.ArticleSet.Count());
            Assert.Equal("Tom Smith", context.ArticleSet.First().Author);
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
            ArticleEntity a1 = new ArticleEntity { Id = 1, Title = "Breaking News Elisabeth 2 Died", Description = "The queen of England died today at the age of 95", DatePublished = "2022-02-06", LectureTime = 2, Author = "Tom Smith" };
            ArticleEntity a2 = new ArticleEntity { Id = 2, Title = "The new iPhone 15", Description = "The new iPhone 15 is out and it's the best phone ever", DatePublished = "2022-02-06", LectureTime = 3, Author = "Tom Smith" };
            ArticleEntity a3 = new ArticleEntity { Id = 3, Title = "M&M's new recipe", Description = "M&M's new recipe is out and it's the best chocolate ever", DatePublished = "2022-02-06", LectureTime = 1, Author = "M&M's Red" };
            context.ArticleSet.Add(a1);
            context.ArticleSet.Add(a2);
            context.ArticleSet.Add(a3);

            context.SaveChanges();

            var article = context.ArticleSet.First(a => a.Title.Equals("Breaking News Elisabeth 2 Died"));
            article.Author = "Louis Laborie";
            context.SaveChanges();
            string persRemove = "Tom Smith";
            string persNew = "Louis Laborie";
            Assert.Equal(1, context.ArticleSet.Count(a => a.Author.Equals(persRemove)));
            Assert.Equal(1, context.ArticleSet.Count(a => a.Author.Equals(persNew)));
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
            ArticleEntity a1 = new ArticleEntity { Id = 1, Title = "Breaking News Elisabeth 2 Died", Description = "The queen of England died today at the age of 95", DatePublished = "2022-02-06", LectureTime = 2, Author = "Tom Smith" };
            ArticleEntity a2 = new ArticleEntity { Id = 2, Title = "The new iPhone 15", Description = "The new iPhone 15 is out and it's the best phone ever", DatePublished = "2022-02-06", LectureTime = 3, Author = "Tom Smith" };
            ArticleEntity a3 = new ArticleEntity { Id = 3, Title = "M&M's new recipe", Description = "M&M's new recipe is out and it's the best chocolate ever", DatePublished = "2022-02-06", LectureTime = 1, Author = "M&M's Red" };

            context.Add(a1);
            context.Add(a2);
            context.Add(a3);

            context.SaveChanges();

            var article = context.ArticleSet.First(a => a.Title.Equals("Breaking News Elisabeth 2 Died"));
            context.Remove(article);
            context.SaveChanges();
            Assert.Equal(2, context.ArticleSet.Count());
            Assert.Equal(0, context.ArticleSet.Count(a => a.Title.Equals("Breaking News Elisabeth 2 Died")));
            connection.Close();
        }
    }

}