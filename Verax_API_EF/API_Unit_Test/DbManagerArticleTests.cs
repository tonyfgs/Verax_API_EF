using DbContextLib;
using DbDataManager;
using Entities;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API_Unit_Test;

public class DbManagerArticleTests
{
    private LibraryContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDbForArticleInMemory" + Guid.NewGuid()) // Ensure a unique name for each test run
                .Options;
            var context = new LibraryContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task GetAllArticles_ReturnsArticlesWithSpecifiedOrder()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                context.ArticleSet.AddRange(
                    new ArticleEntity { Title = "C", LectureTime = 30, DatePublished = "2024-03-16" },
                    new ArticleEntity { Title = "A", LectureTime = 10, DatePublished = "2024-03-16"},
                    new ArticleEntity { Title = "B", LectureTime = 20, DatePublished = "2024-03-16" }
                );
                context.SaveChanges();

                var service = new DbManagerArticle(context);

                // Act & Assert - Test ordering by title
                var articlesByTitle = await service.GetAllArticles(0, 10, ArticleOrderCriteria.ByTitle);
                Assert.Equal("A", articlesByTitle.First().Title);

                // Test ordering by lecture time
                var articlesByLectureTime = await service.GetAllArticles(0, 10, ArticleOrderCriteria.ByLectureTime);
                Assert.Equal(10, articlesByLectureTime.First().LectureTime);
            }
        }

        [Fact]
        public async Task GetArticleById_ReturnsCorrectArticle()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var expectedArticle = new ArticleEntity { Title = "Test Article", Id = 1 };
                context.ArticleSet.Add(expectedArticle);
                context.SaveChanges();

                var service = new DbManagerArticle(context);

                // Act
                var article = await service.GetArticleById(1);

                // Assert
                Assert.NotNull(article);
                Assert.Equal("Test Article", article.Title);
            }
        }

        [Fact]
        public async Task CreateArticle_AddsNewArticleSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var service = new DbManagerArticle(context);
                var newArticle = new Article { Title = "New Article" };

                // Act
                var createdArticle = await service.CreateArticle(newArticle);

                // Assert
                Assert.NotNull(createdArticle);
                Assert.Equal("New Article", createdArticle.Title);
                Assert.Single(context.ArticleSet);
            }
        }

        [Fact]
        public async Task UpdateArticle_UpdatesExistingArticleSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var originalArticle = new ArticleEntity { Id = 2, Title = "Original Title" };
                context.ArticleSet.Add(originalArticle);
                context.SaveChanges();

                var service = new DbManagerArticle(context);
                var updatedArticle = new Article { Id = 2, Title = "Updated Title" };

                // Act
                var result = await service.UpdateArticle(2, updatedArticle);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Updated Title", result.Title);
                Assert.Equal(2, result.Id);
            }
        }

        [Fact]
        public async Task DeleteArticle_RemovesArticleSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var articleToDelete = new ArticleEntity { Id = 3, Title = "Delete Me" };
                context.ArticleSet.Add(articleToDelete);
                context.SaveChanges();

                var service = new DbManagerArticle(context);

                // Act
                var deletedArticle = await service.DeleteArticle(3);

                // Assert
                Assert.NotNull(deletedArticle);
                Assert.DoesNotContain(context.ArticleSet, a => a.Id == 3);
            }
        }
}