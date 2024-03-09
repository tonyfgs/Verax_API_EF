using Entities;
using Model;

namespace StubbedContextLib;

public class StubTest
{
    private List<Article> _article;
    
    public List<Article> StubArticle()
    {
        _article = new List<Article>
        {
            new Article
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