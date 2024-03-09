using Model;

namespace API_Services
{
    public interface IArticleService
    {
        Task<ArticleEntity?> CreateArticle(long id, string title, string description, string author, string date,
            int lectureTime);

        Task<ArticleEntity?> DeleteArticle(long id);

         Task<bool> UpdateArticle(long id, ArticleEntity? a);

        Task<ArticleEntity?> GetArticleById(int id);

        Task<IEnumerable<ArticleEntity?>> GetAllArticles();
        
    }
}
