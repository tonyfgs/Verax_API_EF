namespace Model;
using API_Services;

public interface IDataManager
{
    
    
    IArticleService ArticleService { get; }
    IUserService UserService { get; }
    IFormulaireService FormulaireService { get; }
    
}

