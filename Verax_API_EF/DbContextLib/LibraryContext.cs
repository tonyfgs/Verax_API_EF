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
        
        
        
    }
}