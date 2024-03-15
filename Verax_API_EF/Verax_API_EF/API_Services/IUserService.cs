using Entities;
using Model;

namespace API_Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<User?>> GetAll(int index, int count, UserOrderCriteria orderCriteria);
        Task<User?> GetByPseudo(string pseudo);
        Task<User?> Create(User user);
        Task<User?> Update(User user, string pseudo);

        Task<User?> Delete(string pseudo);
        
        Task<IEnumerable<User?>> GetAllArticleUsers();
        Task<IEnumerable<Article?>> GetArticleUser(string pseudo);
        
        Task<bool> CreateArticleUser(ArticleUserEntity articleUser);
    
        Task<bool> DeleteArticleUser(string pseudo, long id);
    
        Task<bool> UpdateArticleUser(ArticleUserEntity articleUser);

 




    }
}
