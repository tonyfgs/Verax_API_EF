using Entities;
using Web_API.Model;

namespace API_Services
{
    public interface IArticleService
    {
        Task<ArticleDTO> CreateArticle(ArticleDTO a);

        Task<ArticleDTO?> DeleteArticle(long id);

         Task<bool> UpdateArticle(long id, ArticleDTO a);

        Task<ArticleDTO> GetArticleById(int id);

        Task<List<ArticleDTO>> GetAllArticles();
        
    }
}
