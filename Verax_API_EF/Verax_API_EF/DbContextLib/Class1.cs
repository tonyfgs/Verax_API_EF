using DbContextLib;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace StubbedContextLib;

public class StubbedContext : LibraryContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArticleEntity>().HasData(
            new ArticleEntity
            {
                Id = 1,
                Title = "Breaking News Elisabeth 2 Died",
                Description = "The queen of England died today at the age of 95",
                DatePublished = "2022-02-06",
                LectureTime = 2,
                Author = "Tom Smith"

            },
            new ArticleEntity
            {
                Id = 2,
                Title = "The new iPhone 15",
                Description = "The new iPhone 15 is out and it's the best phone ever",
                DatePublished = "2022-02-06",
                LectureTime = 3,
                Author = "Tom Smith"

            },
            new ArticleEntity
            {
                Id = 3,
                Title = "M&M's new recipe",
                Description = "M&M's new recipe is out and it's the best chocolate ever",
                DatePublished = "2022-02-06",
                LectureTime = 1,
                Author = "M&M's Red" 
            }
        );

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                 Nom = "Fages", Prenom = "Tony", Pseudo = "TonyF", Mail = "tony@gmail.com", Mdp = "1234", Role = "Admin"
            },
            new UserEntity
            {
                Nom = "Smith", Prenom = "Tom", Pseudo = "TomS", Mail = "tom@mail.com", Mdp = "1234",
                Role = "User"
            },
            new UserEntity
            {
                 Nom = "M&M's", Prenom = "Red", Pseudo = "RedM", Mail = "M&M#mail.com", Mdp = "1234", Role = "Modérator"
            }
        );
        
        modelBuilder.Entity<ArticleUserEntity>().HasData(
            new ArticleUserEntity
            {
                ArticleEntityId = 1,
                UserEntityPseudo = "Sha"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityPseudo = "Sha"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityPseudo = "Sha"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityPseudo = "Sha"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityPseudo = "Sha"
            }
        );
    }
}