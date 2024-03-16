using DbDataManager;
using Entities;
using Model;

namespace API_Unit_Test;

public class ExtensionsTests
{
    [Fact]
    public void ArticleToEntityMapsCorrectly()
    {
        // Arrange
        var article = new Article
        {
            Id = 1,
            Author = "Author",
            Description = "Description",
            Title = "Title",
            DatePublished = "2021-01-01",
            LectureTime = 10
        };

        // Act
        var entity = article.ToEntity();

        // Assert
        Assert.NotNull(entity);
        Assert.Equal(article.Id, entity.Id);
        Assert.Equal(article.Author, entity.Author);
        Assert.Equal(article.Description, entity.Description);
        Assert.Equal(article.Title, entity.Title);
        Assert.Equal(article.DatePublished, entity.DatePublished);
        Assert.Equal(article.LectureTime, entity.LectureTime);
    }

    [Fact]
    public void ArticleEntityToModelMapsCorrectly()
    {
        // Arrange
        var entity = new ArticleEntity
        {
            Id = 1,
            Author = "Author",
            Description = "Description",
            Title = "Title",
            DatePublished = "2021-01-01",
            LectureTime = 10
        };

        // Act
        var model = entity.ToModel();

        // Assert
        Assert.NotNull(model);
        Assert.Equal(entity.Id, model.Id);
        Assert.Equal(entity.Author, model.Author);
        Assert.Equal(entity.Description, model.Description);
        Assert.Equal(entity.Title, model.Title);
        Assert.Equal(entity.DatePublished, model.DatePublished);
        Assert.Equal(entity.LectureTime, model.LectureTime);
    }

}