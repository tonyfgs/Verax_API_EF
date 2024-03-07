using Model;

namespace API_Services
{
    public interface IArticleService
    {
        Task<Article?> CreateArticle(long id, string title, string description, string author, string date,
            int lectureTime);

        Task<Article?> DeleteArticle(long id);

         Task<bool> UpdateArticle(long id, Article? a);

        Task<Article?> GetArticleById(int id);

        Task<IEnumerable<Article?>> GetAllArticles();
        
    }
}
