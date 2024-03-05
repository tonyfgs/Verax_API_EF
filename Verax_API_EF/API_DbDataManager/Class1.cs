using API_Services;
using DbContextLib;
using Web_API.Mapper;
using Web_API.Model;

namespace DbDataManager;

public class DbDataManager : IArticleService, IFormulaireService, IUserService
{
    
    private readonly LibraryContext _context;
    private Mapper map = new Mapper();
    public DbDataManager(LibraryContext context)
    {
        _context = context;
    }
    
    public Task<ArticleDTO> CreateArticle(ArticleDTO a)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDTO?> DeleteArticle(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateArticle(long id, ArticleDTO a)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDTO> GetArticleById(int id)
    {
        var article = _context.ArticleSet.Find(id);
        return Task.FromResult(map.ArtEntityToDTO(article));
    }

    public Task<List<ArticleDTO>> GetAllArticles()
    {
        var articles = _context.ArticleSet.ToList();
        return Task.FromResult(map.ArtEntityToDTO(articles));
    }

    public Task<List<FormulaireDTO>> GetAllForm()
    {
        throw new NotImplementedException();
    }

    public Task<FormulaireDTO?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<FormulaireDTO> CreateForm(Formulaire formulaire)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteForm(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateForm(long id, Formulaire formulaire)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string pseudo)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByPseudo(string pseudo)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDTO>> GetAll()
    {
        throw new NotImplementedException();
    }
}