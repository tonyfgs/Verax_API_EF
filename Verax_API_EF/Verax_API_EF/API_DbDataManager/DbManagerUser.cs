using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerUser: IUserService
{
    
    private readonly LibraryContext _context;

    public DbManagerUser(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Create(User user)
    {
        var entity = new UserEntity()
        {
            Pseudo = user.Pseudo,
            Prenom = user.Prenom,
            Nom = user.Nom,
            Mdp = user.Mdp,
            Mail = user.Mail,
            Role = user.Role
        };
        _context.UserSet.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(User user, string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        if (entity == null) return false;
        entity.Mdp = user.Mdp;
        entity.Mail = user.Mail;
        entity.Role = user.Role;
        entity.Prenom = user.Prenom;
        entity.Nom = user.Nom;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        if (entity == null) return await Task.FromResult(false);
        _context.UserSet.Remove(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
        
    }

    public async Task<User?> GetByPseudo(string pseudo)
    {
        var entity = _context.UserSet.FirstOrDefault(u => u.Pseudo == pseudo);
        return await Task.FromResult(entity.ToModel());
    }

    public async Task<IEnumerable<User?>> GetAll(int index, int count, UserOrderCriteria orderCriteria)
    {
        List<User> users = new List<User>();
        switch(orderCriteria)
        {
            case UserOrderCriteria.None:
                users = _context.UserSet.Select(u => u.ToModel()).ToList();
                break;
            case UserOrderCriteria.ByFirstName:
                users = _context.UserSet.OrderBy(u => u.Prenom).Select(u => u.ToModel()).ToList();
                break;
            case UserOrderCriteria.ByLastName:
                users = _context.UserSet.OrderBy(u => u.Nom).Select(u => u.ToModel()).ToList();
                break;
            default:
                users = _context.UserSet.Select(u => u.ToModel()).ToList();
                break;

        }
        return await Task.FromResult(users.AsEnumerable());

    }
}