using Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContextLib;

public class LibraryContext : DbContext
{
    public LibraryContext()
        : base()
    { }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    { }
    
    
    
    public DbSet<ArticleEntity> ArticleSet { get; set; }
    public DbSet<UserEntity> UserSet { get; set; }
    public DbSet<FormEntity> FormSet { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
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
                Id = 1, Nom = "Fages", Prenom = "Tony", Pseudo = "TonyF", Mail = "tony@gmail.com", Mdp = "1234", Role = "Admin"
            },
            new UserEntity
            {
                Id = 2, Nom = "Smith", Prenom = "Tom", Pseudo = "TomS", Mail = "tom@mail.com", Mdp = "1234",
                Role = "User"
            },
            new UserEntity
            {
                Id = 3, Nom = "M&M's", Prenom = "Red", Pseudo = "RedM", Mail = "M&M#mail.com", Mdp = "1234", Role = "Modérator"
            }
        );
        
        modelBuilder.Entity<ArticleUserEntity>().HasData(
            new ArticleUserEntity
            {
                ArticleEntityId = 1,
                UserEntityId = 1
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityId = 2
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityId = 3
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 3,
                UserEntityId = 1
            },
            new ArticleUserEntity
            {
                ArticleEntityId = 2,
                UserEntityId = 3
            }
        );
    }
}