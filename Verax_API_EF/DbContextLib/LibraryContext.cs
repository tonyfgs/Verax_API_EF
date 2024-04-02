using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbContextLib;

public class LibraryContext : DbContext
{

    public LibraryContext()
        : base()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }



    public DbSet<ArticleEntity> ArticleSet { get; set; }
    public DbSet<UserEntity> UserSet { get; set; }
    public DbSet<FormEntity> FormSet { get; set; }

    public DbSet<ArticleUserEntity> ArticleUserSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message =>
        {
            using var logFile = new StreamWriter("log.txt", append: true);
            logFile.WriteLine(message);
        }, LogLevel.Information);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source=Entity_FrameWork.Article.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArticleEntity>()
            .HasMany(a => a.Users)
            .WithMany(a => a.Articles)
            .UsingEntity<ArticleUserEntity>();

        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.Forms)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserEntityPseudo);

        modelBuilder.Entity<FormEntity>()
            .HasOne(f => f.User)
            .WithMany(u => u.Forms)
            .HasForeignKey(f => f.UserEntityPseudo);
        
        // En cas de besoin, decomenter les lignes suivantes afin de faire la migration
        /*
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
            },
            new UserEntity
            {
                 Nom = "Cascarra", Prenom = "Cascarra", Pseudo = "Sha",   Mail = "ShaCasca@gmail.com", Mdp = "1234", Role = "Admin"
            },
            new UserEntity
            {
                Nom = "Sillard", Prenom = "Noa", Pseudo = "NoaSil", Mail = "", Mdp = "1234", Role = "Admin"
            }
        );

        modelBuilder.Entity<ArticleUserEntity>().HasData(
            new ArticleUserEntity
            {
                ArticleEntityId = 1,
                UserEntityPseudo = "TonyF"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityPseudo = "NoaSil"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityPseudo = "Sha"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityPseudo = "RedM"
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityPseudo = "TomS"
            }
        );

        modelBuilder.Entity<FormEntity>().HasData(
            new FormEntity
            {
                Id = 1,
                Theme = "Form 1 Theme",
                DatePublication = "Form 1 Description",
                Link = "hhtp://form1.com",
                UserEntityPseudo = "Sha"
            },
            new FormEntity
            {
                Id = 2,
                Theme = "Form 2 Theme",
                DatePublication = "Form 2 Description",
                Link = "hhtp://form2.com",
                UserEntityPseudo = "Sha"
            },
            new FormEntity
            {
                Id = 3,
                Theme = "Form 3 Theme",
                DatePublication = "Form 3 Description",
                Link = "hhtp://form3.com",
                UserEntityPseudo = "Sha"
            }
        );
        */
        
    }
}