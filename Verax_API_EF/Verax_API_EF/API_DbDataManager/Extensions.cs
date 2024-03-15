using Entities;
using Model;

namespace DbDataManager;

public static class Extensions
{
    public static Entities.ArticleEntity ToEntity(this Article article)
        => new Entities.ArticleEntity
        {
            Id = article.Id, Author = article.Author, Description = article.Description, Title = article.Title,
            DatePublished = article.DatePublished, LectureTime = article.LectureTime 
        };
    
    public static Article ToModel(this Entities.ArticleEntity article)
        => new Article
        {
            Id = article.Id, Author = article.Author, Description = article.Description, Title = article.Title,
            DatePublished = article.DatePublished, LectureTime = article.LectureTime
        };
    
    public static UserEntity ToEntity(this User user)
    => new UserEntity{ Pseudo = user.Pseudo, Mdp = user.Mdp, Prenom = user.Prenom, Nom = user.Nom, Mail = user.Mail, Role = user.Role};
    
    public static User ToModel(this UserEntity user)
    => new User{ Pseudo = user.Pseudo, Mdp = user.Mdp, Prenom = user.Prenom, Nom = user.Nom, Mail = user.Mail, Role = user.Role};
    
    public static FormEntity ToEntity(this Formulaire form)
    => new FormEntity{ Id = form.Id, UserEntityPseudo = form.UserPseudo, Theme = form.Theme, Link = form.Lien};
    
    public static Formulaire ToModel(this FormEntity form)
    => new Formulaire{ Id = form.Id, UserPseudo = form.UserEntityPseudo, Theme = form.Theme, Lien = form.Link};
    

}