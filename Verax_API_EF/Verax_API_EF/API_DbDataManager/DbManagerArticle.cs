using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;


public class DbManagerArticle : IArticleService
{
    private readonly LibraryContext _context;

    public DbManagerArticle(LibraryContext context)
        => this._context = context;
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
    
    public Task<Article?> GetArticleById(int id)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        if (entity == null) return Task.FromResult<Article?>(null);
        return Task.FromResult(entity.ToModel());
    }

    
    public async Task<Article?> CreateArticle(Article article)
    {
        var entity = new Entities.ArticleEntity()
        {
            Id = article.Id,
            Title = article.Title,
            Description = article.Description,
            Author = article.Author,
            DatePublished = article.DatePublished,
            LectureTime = article.LectureTime, 
        };
        _context.ArticleSet.Add(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Article?>(null);        
        return entity.ToModel();
    }
    
    public async Task<Article?> DeleteArticle(long id)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        Console.WriteLine(entity);
        if (entity == null) return null;
        _context.ArticleSet.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Article?>(null);
        return entity.ToModel();
    }

    public async Task<Article?> UpdateArticle(long id, Article? a)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        if (entity == null) return await Task.FromResult<Article?>(null);
        entity.Title = a.Title;
        entity.Description = a.Description;
        entity.Author = a.Author;
        entity.DatePublished = a.DatePublished;
        entity.LectureTime = a.LectureTime;
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Article?>(null);
        return entity.ToModel();
    }
    
    
    
}