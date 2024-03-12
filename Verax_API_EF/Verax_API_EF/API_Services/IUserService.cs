﻿using Entities;
using Model;

namespace API_Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<User?>> GetAll(int index, int count, UserOrderCriteria orderCriteria);
        Task<User?> GetByPseudo(string pseudo);
        Task<bool> Create(User user);
        Task<bool> Update(User user, string pseudo);

        Task<bool> Delete(string pseudo);
        
        Task<IEnumerable<User?>> GetAllArticleUsers();
        Task<IEnumerable<Article?>> GetArticleUser(string pseudo);
        
        Task<bool> CreateArticleUser(ArticleUserEntity articleUser);
    
        Task<bool> DeleteArticleUser(string pseudo);
    
        Task<bool> UpdateArticleUser(ArticleUserEntity articleUser);

 




    }
}
