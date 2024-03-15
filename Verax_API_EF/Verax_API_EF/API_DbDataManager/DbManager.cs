using API_Services;
using DbContextLib;
using Model;

namespace DbDataManager;

public class DbManager : IDataManager
{
    protected LibraryContext _context { get; set; }
    
    public DbManager()
    {
        _context = new LibraryContext();
        ArticleService = new DbManagerArticle(_context);
        UserService = new DbManagerUser(_context);
        FormulaireService = new DbManagerFormulaire(_context);
    }
    
    public DbManager(LibraryContext context)
    {
        _context = context;
        ArticleService = new DbManagerArticle(_context);
        UserService = new DbManagerUser(_context);
        FormulaireService = new DbManagerFormulaire(_context);
    }

    public IArticleService ArticleService { get; set; }
    public IUserService UserService { get; set; }
    public IFormulaireService FormulaireService { get; set; }
}