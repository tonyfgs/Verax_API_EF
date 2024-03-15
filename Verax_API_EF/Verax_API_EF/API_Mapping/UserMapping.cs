using Model;
using Web_API.Model;

namespace API_Mapping;

public static class UserMapping
{
    public static UserDTO ToDTO(this User? u) => new()
    {
        Pseudo = u.Pseudo,
        Mdp = u.Mdp,
        Nom = u.Nom,
        Prenom = u.Prenom,
        Mail = u.Mail,
        Role = u.Role
    };
    
    public static User ToModel(this UserDTO u) => new()
    {
        Pseudo = u.Pseudo,
        Mdp = u.Mdp,
        Nom = u.Nom,
        Prenom = u.Prenom,
        Mail = u.Mail,
        Role = u.Role
    };
}