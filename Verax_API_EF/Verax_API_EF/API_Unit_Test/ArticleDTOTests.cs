using Web_API.Model;

namespace API_Unit_Test;

public class ArticleDTOTests
{
    [Fact]
    public void ArticleDTOPropertiesTest()
    {
        // Arrange
        var articleDTO = new ArticleDTO();
        var testId = 1L;
        var testTitle = "Test Title";
        var testDescription = "Test Description";
        var testDatePublished = "2024-03-16";
        var testLectureTime = 5;
        var testAuthor = "Test Author";

        // Act
        articleDTO.Id = testId;
        articleDTO.Title = testTitle;
        articleDTO.Description = testDescription;
        articleDTO.DatePublished = testDatePublished;
        articleDTO.LectureTime = testLectureTime;
        articleDTO.Author = testAuthor;

        // Assert
        Assert.Equal(testId, articleDTO.Id);
        Assert.Equal(testTitle, articleDTO.Title);
        Assert.Equal(testDescription, articleDTO.Description);
        Assert.Equal(testDatePublished, articleDTO.DatePublished);
        Assert.Equal(testLectureTime, articleDTO.LectureTime);
        Assert.Equal(testAuthor, articleDTO.Author);
    }
}