using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;


public class DbManagerArticle : IArticleService
{
    private readonly LibraryContext _context;

    public DbManagerArticle(LibraryContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Article?>> GetAllArticles(int index, int count, ArticleOrderCriteria orderCriterium)
    {
        List<Article> articles = new List<Article>();
        
        switch (orderCriterium)
        {
            case ArticleOrderCriteria.None:
                articles = _context.ArticleSet.Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByLectureTime:
                articles = _context.ArticleSet.OrderBy(a => a.LectureTime).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByTitle:
                articles = _context.ArticleSet.OrderBy(a => a.Title).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByAuthor:
                articles = _context.ArticleSet.OrderBy(a => a.Author).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByDatePublished:
                articles = _context.ArticleSet.OrderBy(a => a.DatePublished).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByDescription:
                articles = _context.ArticleSet.OrderBy(a => a.Description).Select(a => a.ToModel()).ToList();
                break;
            default:
                articles = _context.ArticleSet.Select(a => a.ToModel()).ToList();
                break;
        }
        return await Task.FromResult(articles.AsEnumerable());
    }
    
    public Task<Article?> GetArticleById(int id, int index, int count, ArticleOrderCriteria orderCriterium)
    {
        List<Article> articles = new List<Article>();
        switch (orderCriterium)
        {
            case ArticleOrderCriteria.None:
                articles = _context.ArticleSet.Where(a => a.Id == id).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByLectureTime:
                articles = _context.ArticleSet.Where(a => a.Id == id).OrderBy(a => a.LectureTime).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByTitle:
                articles = _context.ArticleSet.Where(a => a.Id == id).OrderBy(a => a.Title).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByAuthor:
                articles = _context.ArticleSet.Where(a => a.Id == id).OrderBy(a => a.Author).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByDatePublished:
                articles = _context.ArticleSet.Where(a => a.Id == id).OrderBy(a => a.DatePublished).Select(a => a.ToModel()).ToList();
                break;
            case ArticleOrderCriteria.ByDescription:
                articles = _context.ArticleSet.Where(a => a.Id == id).OrderBy(a => a.Description).Select(a => a.ToModel()).ToList();
                break;
            default:
                articles = _context.ArticleSet.Where(a => a.Id == id).Select(a => a.ToModel()).ToList();
                break;
        }
        return Task.FromResult(articles.FirstOrDefault());
    }

    
    public async Task<Article?> CreateArticle(long id, string title, string description, string author, string date, int lectureTime)
    {
        var entity = new Entities.ArticleEntity()
        {
            Id = id,
            Title = title,
            Description = description,
            Author = author,
            DatePublished = date,
            LectureTime = lectureTime, 
        };
        _context.ArticleSet.Add(entity);
        await _context.SaveChangesAsync();
        
        return entity.ToModel();
    }
    
    public async Task<Article?> DeleteArticle(long id)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        Console.WriteLine(entity);
        if (entity == null) return null;
        _context.ArticleSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity.ToModel();
    }

    public async Task<bool> UpdateArticle(long id, Article? a)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        if (entity == null) return false;
        entity.Title = a.Title;
        entity.Description = a.Description;
        entity.Author = a.Author;
        entity.DatePublished = a.DatePublished;
        entity.LectureTime = a.LectureTime;
        await _context.SaveChangesAsync();
        return true;
    }

    
}