using Model;
using Web_API.Model;

namespace API_Mapping;

public static class ArticleMapper
{
    public static ArticleDTO ToDTO(this Article? a) => new()
    {
        Id = a.Id,
        Title = a.Title,
        Description = a.Description,
        DatePublished = a.DatePublished,
        LectureTime = a.LectureTime,
        Author = a.Author
    };
    
    public static Article ToModel(this ArticleDTO a) => new()
    {
        Id = a.Id,
        Title = a.Title,
        Description = a.Description,
        DatePublished = a.DatePublished,
        LectureTime = a.LectureTime,
        Author = a.Author
    };
}