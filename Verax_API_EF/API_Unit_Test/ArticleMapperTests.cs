using API_Mapping;
using Model;
using Web_API.Model;

namespace API_UnitTest_Mapper;

public class ArticleMapperTests
{
    [Fact]
    public void ToDTOMapsCorrectly()
    {
        var article = new Article
        {
            Id = 1,
            Title = "Test Article",
            Description = "Test Description",
            DatePublished = "2021-01-01",
            LectureTime = 5,
            Author = "Test Author"
        };
        var dto = ArticleMapper.ToDTO(article);

        Assert.NotNull(dto);
        Assert.Equal(article.Id, dto.Id);
        Assert.Equal(article.Title, dto.Title);
        Assert.Equal(article.Description, dto.Description);
        Assert.Equal(article.DatePublished, dto.DatePublished);
        Assert.Equal(article.LectureTime, dto.LectureTime);
        Assert.Equal(article.Author, dto.Author);
    }
    
    [Fact]
    public void ToModelMapsCorrectly()
    {
        var dto = new ArticleDTO
        {
            Id = 2,
            Title = "Another Test Article",
            Description = "Another Test Description",
            DatePublished = "2021-01-02",
            LectureTime = 10,
            Author = "Another Test Author"
        };

        var article = ArticleMapper.ToModel(dto);

        Assert.NotNull(article);
        Assert.Equal(dto.Id, article.Id);
        Assert.Equal(dto.Title, article.Title);
        Assert.Equal(dto.Description, article.Description);
        Assert.Equal(dto.DatePublished, article.DatePublished);
        Assert.Equal(dto.LectureTime, article.LectureTime);
        Assert.Equal(dto.Author, article.Author);
    }

    [Fact]
    public void ToDTONullArticleThrowsNullReferenceException()
    {
        Article article = null;

        Assert.Throws<NullReferenceException>(() => ArticleMapper.ToDTO(article));
    }
    
    [Fact]
    public void ToModelNullArticleDTOThrowsNullReferenceException()
    {
        ArticleDTO dto = null;

        Assert.Throws<NullReferenceException>(() => ArticleMapper.ToModel(dto));
    }

}