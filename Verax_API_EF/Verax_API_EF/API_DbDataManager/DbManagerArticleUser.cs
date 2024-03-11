using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerArticleUser : IArticleUserService
{
    private readonly LibraryContext _context;
    
    public DbManagerArticleUser(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ArticleUserEntity?>> GetAllArticleUsers()
    {
        var entities = _context.ArticleUserSet.ToList();
        if (entities == null) return await Task.FromResult<IEnumerable<ArticleUserEntity?>>(null);
        return await Task.FromResult(entities.AsEnumerable());
    }

    public async Task<ArticleUserEntity?> GetArticleUser(string pseudo)
    {
        var entity = _context.ArticleUserSet.FirstOrDefault(a => a.UserEntityPseudo.Equals(pseudo));
        if (entity == null) return await Task.FromResult<ArticleUserEntity?>(null);
        return await Task.FromResult(entity);
    }
    
    
    public async Task<ArticleUserEntity?> CreateArticleUser(ArticleUserEntity articleUser)
    {
        var result = await GetArticleUser(articleUser.UserEntityPseudo);
        if (result != null) return await Task.FromResult<ArticleUserEntity?>(null);
        var entity = new ArticleUserEntity()
        {
            ArticleEntityId = articleUser.ArticleEntityId,
            UserEntityPseudo = articleUser.UserEntityPseudo
        };
        if (entity == null) return await Task.FromResult<ArticleUserEntity?>(null);
        _context.ArticleUserSet.Add(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(entity);
    }
    
    public async Task<bool> DeleteArticleUser(string pseudo)
    {
        var entity = _context.ArticleUserSet.FirstOrDefault(a => a.UserEntityPseudo.Equals(pseudo));
        if (entity == null) return await Task.FromResult(false);
        _context.ArticleUserSet.Remove(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<bool> UpdateArticleUser(ArticleUserEntity articleUser)
    {
        var entity = _context.ArticleUserSet.FirstOrDefault(a => a.UserEntityPseudo.Equals(articleUser.UserEntityPseudo));
        if (entity == null) return await Task.FromResult(false);
        entity.ArticleEntityId = articleUser.ArticleEntityId;
        entity.UserEntityPseudo = articleUser.UserEntityPseudo;
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    
}