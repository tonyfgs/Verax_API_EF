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

    public async Task<Article?> CreateArticle(long id, string title, string description, string author, string date, int lectureTime)
    {
        var entity = new ArticleEntity()
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

    public Task<Article?> GetArticleById(int id)
    {
        var entity = _context.ArticleSet.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(entity.ToModel());
    }

    public async Task<IEnumerable<Article?>> GetAllArticles()
    {
        return await Task.FromResult(_context.ArticleSet.Select(a => a.ToModel()).AsEnumerable());
    }
}