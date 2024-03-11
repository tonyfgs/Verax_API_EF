using Entities;

namespace API_Services;

public interface IArticleUserService
{
    Task<IEnumerable<ArticleUserEntity>> GetAllArticleUsers();
    Task<ArticleUserEntity?> GetArticleUser(string pseudo);
        
    Task<ArticleUserEntity?> CreateArticleUser(ArticleUserEntity articleUser);
    
    Task<bool> DeleteArticleUser(string pseudo);
    
    Task<bool> UpdateArticleUser(ArticleUserEntity articleUser);
}