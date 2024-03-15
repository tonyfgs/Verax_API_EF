using Model;

namespace API_Services
{
    public interface IArticleService
    {
        
        Task<IEnumerable<Article?>> GetAllArticles(int index, int count, ArticleOrderCriteria orderCriterium);
        
        Task<Article?> GetArticleById(int id);


        Task<Article?> CreateArticle(Article article);

        Task<Article?> DeleteArticle(long id);

         Task<Article?> UpdateArticle(long id, Article? a);

       
    }
}
