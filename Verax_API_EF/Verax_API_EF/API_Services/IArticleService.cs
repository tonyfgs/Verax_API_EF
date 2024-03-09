using Model;

namespace API_Services
{
    public interface IArticleService
    {
        
        Task<IEnumerable<Article?>> GetAllArticles(int index, int count, ArticleOrderCriteria orderCriterium);
        
        Task<Article?> GetArticleById(int id, int index, int count, ArticleOrderCriteria orderCriterium);


        Task<Article?> CreateArticle(long id, string title, string description, string author, string date,
            int lectureTime);

        Task<Article?> DeleteArticle(long id);

         Task<bool> UpdateArticle(long id, Article? a);

       
    }
}
