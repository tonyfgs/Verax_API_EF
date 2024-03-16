using API_Services;
using Model;
using Moq;

namespace API_Unit_Test;

public class IArticleServiceTests
{
    
    
    
    
    
    [Fact]
    public void TestGetArticleById()
    {
        var mockArticleService = new Mock<IArticleService>();
        var expected = new Article()
        {
            Id = 1,
            Title = "Test",
            Description = "Test",
            Author = "Test",
            DatePublished = "Test",
            LectureTime = 10
        };
        mockArticleService.Setup(x => x.GetArticleById(1)).ReturnsAsync(expected);
        var result = mockArticleService.Object.GetArticleById(1);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void TestGetAllArticles()
    {
        var mockArticleService = new Mock<IArticleService>();
        var expected = new List<Article>()
        {
            new Article()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 10
            },
            new Article()
            {
                Id = 2,
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 10
            }
        };
        mockArticleService.Setup(x => x.GetAllArticles(0, 10, ArticleOrderCriteria.None)).ReturnsAsync(expected);
        var result = mockArticleService.Object.GetAllArticles(0, 10, ArticleOrderCriteria.None);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void TestAddArticle()
    {
        var mockArticleService = new Mock<IArticleService>();
        var expected = new Article()
        {
            Id = 1,
            Title = "Test",
            Description = "Test",
            Author = "Test",
            DatePublished = "Test",
            LectureTime = 10
        };
        mockArticleService.Setup(x => x.CreateArticle(expected)).ReturnsAsync(expected);
        var result = mockArticleService.Object.CreateArticle(expected);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void UpdateArticle()
    {
        var mockArticleService = new Mock<IArticleService>();
        var expected = new Article()
        {
            Title = "Test",
            Description = "Test",
            Author = "Test",
            DatePublished = "Test",
            LectureTime = 10
        };
        mockArticleService.Setup(x => x.CreateArticle(expected));
        var result = mockArticleService.Object.CreateArticle(expected);
        Assert.Equal(1, result.Id );
        var updated = new Article()
        {
            Title = "Updated Test",
            Description = "Test",
            Author = "Test",
            DatePublished = "Test",
            LectureTime = 10
        };
        mockArticleService.Setup(x => x.UpdateArticle(1, updated)).ReturnsAsync(updated);
        var resultUpdated = mockArticleService.Object.UpdateArticle(1, updated); 
        Assert.Equal(updated ,resultUpdated.Result);
    }
    
    [Fact]
    static void DeletedArticle()
    {
        var mockArticleService = new Mock<IArticleService>();
        var expected = new Article()
        {
            Id = 1,
            Title = "Test",
            Description = "Test",
            Author = "Test",
            DatePublished = "Test",
            LectureTime = 10
        };
        mockArticleService.Setup(x => x.CreateArticle(expected)).ReturnsAsync(expected);
        var result = mockArticleService.Object.CreateArticle(expected);
        Assert.Equal(expected, result.Result);
        mockArticleService.Setup(x => x.DeleteArticle(1)).ReturnsAsync(expected);
        var resultDeleted = mockArticleService.Object.DeleteArticle(1);
        Assert.Equal(expected, result.Result);
    }
    
}