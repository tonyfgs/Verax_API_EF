using Web_API.Model;

namespace API_Services
{
    public interface IUserService
    {
        Task<bool> Create(User user);
        Task<bool> Update(User user);

        Task<bool> Delete(string pseudo);


        Task<User> GetByPseudo(string pseudo);

        Task<List<UserDTO>> GetAll();



    }
}
