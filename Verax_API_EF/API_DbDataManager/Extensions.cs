using Entities;
using Model;
using ArticleEntity = Model.ArticleEntity;

namespace DbDataManager;

public static class Extensions
{
    public static Entities.ArticleEntity ToEntity(this ArticleEntity articleEntity)
        => new Entities.ArticleEntity
        {
            Id = articleEntity.Id, Author = articleEntity.Author, Description = articleEntity.Description, Title = articleEntity.Title,
            DatePublished = articleEntity.DatePublished, LectureTime = articleEntity.LectureTime 
        };
    
    public static ArticleEntity ToModel(this Entities.ArticleEntity article)
        => new ArticleEntity
        {
            Id = article.Id, Author = article.Author, Description = article.Description, Title = article.Title,
            DatePublished = article.DatePublished, LectureTime = article.LectureTime
        };
    
    public static UserEntity ToEntity(this User user)
    => new UserEntity{ Pseudo = user.Pseudo, Mdp = user.Mdp, Prenom = user.Prenom, Nom = user.Nom, Mail = user.Mail, Role = user.Role};
    
    public static User ToModel(this UserEntity user)
    => new User{ Pseudo = user.Pseudo, Mdp = user.Mdp, Prenom = user.Prenom, Nom = user.Nom, Mail = user.Mail, Role = user.Role};
    
    public static FormEntity ToEntity(this Formulaire form)
    => new FormEntity{ Id = form.Id, Pseudo = form.Pseudo, Theme = form.Theme, Link = form.Lien};
    
    public static Formulaire ToModel(this FormEntity form)
    => new Formulaire{ Id = form.Id, Pseudo = form.Pseudo, Theme = form.Theme, Lien = form.Link};
    

}