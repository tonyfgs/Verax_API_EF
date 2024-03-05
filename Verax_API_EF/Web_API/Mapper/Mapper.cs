using Entities;
using Web_API.Model;

namespace Web_API.Mapper;

public class Mapper
{
    public ArticleDTO ArtEntityToDTO(ArticleEntity a)
    {
        return new ArticleDTO
        {
            Id = a.Id,
            Author = a.Author,
            Title = a.Title,
            Description = a.Description,
            LectureTime = a.LectureTime,
            DatePublished = a.DatePublished
        };
    }


    public ArticleEntity ArtDTOToEntity(ArticleDTO a)
    {
        return new ArticleEntity()
        {
            Id = a.Id,
            Author = a.Author,
            Title = a.Title,
            Description = a.Description,
            LectureTime = a.LectureTime,
            DatePublished = a.DatePublished
        };
    }
    
    public FormulaireDTO FormEntityToDTO(FormEntity f)
    {
        return new FormulaireDTO
        {
            Theme = f.Theme,
            Date = f.DatePublication,
            Lien = f.Lien,
            Pseudo = f.Pseudo
        };
    }
    
    public Formulaire FormDTOToEntity(FormulaireDTO f)
    {
        return new Formulaire
        {
            Theme = f.Theme,
            Date = f.Date,
            Lien = f.Lien,
            Pseudo = f.Pseudo
        };
    }
    
    public UserDTO UserEntityToDTO(User u)
    {
        return new UserDTO
        {
            Pseudo = u.Pseudo,
            Mail = u.Mail,
            Prenom = u.Prenom,
            Nom = u.Nom,
            Role = u.Role,
            Mdp = u.Mdp
        };
    } 
    
    public User UserDTOToEntity(UserDTO u)
    {
        return new User
        {
            Pseudo = u.Pseudo,
            Mail = u.Mail,
            Prenom = u.Prenom,
            Nom = u.Nom,
            Role = u.Role,
            Mdp = u.Mdp
        };
    }
}