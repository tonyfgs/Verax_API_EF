using Entities;
using Model;
using ArticleEntity = Model.ArticleEntity;

namespace StubbedContextLib;

public class StubTest
{
    private List<ArticleEntity> _article;
    
    public List<ArticleEntity> StubArticle()
    {
        _article = new List<ArticleEntity>
        {
            new ArticleEntity
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 1
            }
        };
        return _article;
    }
}