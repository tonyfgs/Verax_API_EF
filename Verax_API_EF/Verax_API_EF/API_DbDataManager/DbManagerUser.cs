using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerUser: IUserService
{
    
    private readonly LibraryContext _context;

    public DbManagerUser(LibraryContext context)
        => this._context = context;
    
    public async Task<IEnumerable<User?>> GetAll(int index, int count, UserOrderCriteria orderCriteria)
    {
        List<User> users = new List<User>();
        switch(orderCriteria)
        {
            case UserOrderCriteria.None:
                users = _context.UserSet.Skip(index * count).Select(u => u.ToModel()).ToList();
                break;
            case UserOrderCriteria.ByFirstName:
                users = _context.UserSet.Skip(index * count).OrderBy(u => u.Prenom).Select(u => u.ToModel()).ToList();
                break;
            case UserOrderCriteria.ByLastName:
                users = _context.UserSet.Skip(index * count).OrderBy(u => u.Nom).Select(u => u.ToModel()).ToList();
                break;
            default:
                users = _context.UserSet.Skip(index * count).Select(u => u.ToModel()).ToList();
                break;

        }
        return await Task.FromResult(users.AsEnumerable());

    }
    
    public async Task<User?> GetByPseudo(string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        if (entity == null) return await Task.FromResult<User?>(null);
        return await Task.FromResult(entity.ToModel());
    }
    
    public async Task<User?> Create(User user)
    {
        var entity = new UserEntity()
        {
            Pseudo = user.Pseudo,
            Prenom = user.Prenom,
            Nom = user.Nom,
            Mdp = user.Mdp,
            Mail = user.Mail,
            Role = user.Role
        };
        _context.UserSet.Add(entity);
        var result =  await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<User?>(null);
        return await Task.FromResult(entity.ToModel());
    }

    public async Task<User?> Update(User user, string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        if (entity == null) return await Task.FromResult<User?>(null);
        entity.Mdp = user.Mdp;
        entity.Mail = user.Mail;
        entity.Role = user.Role;
        entity.Prenom = user.Prenom;
        entity.Nom = user.Nom;
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<User?>(null);
        return await Task.FromResult(entity.ToModel());
    }

    public async Task<User?> Delete(string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        if (entity == null) return await Task.FromResult<User?>(null);
        _context.UserSet.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<User?>(null);
        return await Task.FromResult(entity.ToModel());
    }
    
    public async Task<IEnumerable<User?>> GetAllArticleUsers()
    {
        var entities = _context.ArticleUserSet.ToList();
        List<UserEntity> users = new List<UserEntity>();
        foreach( var articleUser in entities)
        {
            var user = _context.UserSet.FirstOrDefault(u => u.Pseudo.Equals(articleUser.UserEntityPseudo));
            if (user != null) users.Add(user);
        }
        if (users == null) return await Task.FromResult<IEnumerable<User?>>(null);
        return await Task.FromResult(users.Select(u => u.ToModel()).AsEnumerable());
    }

    
    public async Task<IEnumerable<Article?>> GetArticleUser(string pseudo)
    {
        var entities = _context.ArticleUserSet.Where(a => a.UserEntityPseudo.Equals(pseudo));
        List<ArticleEntity> articles = new List<ArticleEntity>();
        foreach (var article in entities)
        {
            var art = _context.ArticleSet.FirstOrDefault(a => a.Id.Equals(article.ArticleEntityId));
            if (art != null) articles.Add(art);
        }
        if (articles == null) return await Task.FromResult<IEnumerable<Article?>>(null);
        return await Task.FromResult(articles.Select(a => a.ToModel()).AsEnumerable());
    }
    
    
    public async Task<bool> CreateArticleUser(ArticleUserEntity articleUser)
    {
        var result = await GetByPseudo(articleUser.UserEntityPseudo);
        if (result == null) return await Task.FromResult(false);
        var entity = new ArticleUserEntity()
        {
            ArticleEntityId = articleUser.ArticleEntityId,
            UserEntityPseudo = articleUser.UserEntityPseudo
        };
        if (entity == null) return await Task.FromResult(false);
        _context.ArticleUserSet.Add(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<bool> DeleteArticleUser(string pseudo, long id)
    {
        
        var entity = _context.ArticleUserSet.FirstOrDefault(a => a.UserEntityPseudo.Equals(pseudo) && a.ArticleEntityId.Equals(id));
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