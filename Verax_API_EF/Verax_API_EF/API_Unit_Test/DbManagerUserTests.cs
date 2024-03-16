using DbContextLib;
using DbDataManager;
using Entities;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API_Unit_Test;

 public class DbManagerUserTests
    {
        private LibraryContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDbInMemory")
                .Options;
            var dbContext = new LibraryContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        [Fact]
        public async Task GetAll_ReturnsCorrectUsers()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                context.UserSet.AddRange(new UserEntity { Pseudo = "user1" }, new UserEntity { Pseudo = "user2" });
                context.SaveChanges();

                var service = new DbManagerUser(context);

                // Act
                var users = await service.GetAll(0, 10, UserOrderCriteria.None);

                // Assert
                Assert.Equal(2, users.Count());
            }
        }

        [Fact]
        public async Task GetByPseudo_UserExists_ReturnsUser()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var pseudo = "user1";
                context.UserSet.Add(new UserEntity { Pseudo = pseudo });
                context.SaveChanges();

                var service = new DbManagerUser(context);

                // Act
                var user = await service.GetByPseudo(pseudo);

                // Assert
                Assert.NotNull(user);
                Assert.Equal(pseudo, user.Pseudo);
            }
        }

        [Fact]
        public async Task Create_AddsUserSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var service = new DbManagerUser(context);
                var newUser = new User { Pseudo = "newUser", Nom = "Doe", Prenom = "John", Mdp = "password", Mail = "mail@mail.com", Role = "Admin" };

                // Act
                var createdUser = await service.Create(newUser);

                // Assert
                Assert.NotNull(createdUser);
                Assert.Equal("newUser", createdUser.Pseudo);
            }
        }

        [Fact]
        public async Task Update_UpdatesUserSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var pseudo = "userToUpdate";
                context.UserSet.Add(new UserEntity { Pseudo = pseudo });
                context.SaveChanges();

                var service = new DbManagerUser(context);
                var updatedInfo = new User { Pseudo = pseudo, Nom = "UpdatedLastName" };

                // Act
                var updatedUser = await service.Update(updatedInfo, pseudo);

                // Assert
                Assert.NotNull(updatedUser);
                Assert.Equal("UpdatedLastName", updatedUser.Nom);
            }
        }

        [Fact]
        public async Task Delete_RemovesUserSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var pseudo = "userToDelete";
                context.UserSet.Add(new UserEntity { Pseudo = pseudo });
                context.SaveChanges();

                var service = new DbManagerUser(context);

                // Act
                var deletedUser = await service.Delete(pseudo);

                // Assert
                Assert.NotNull(deletedUser);
                Assert.Empty(context.UserSet.Where(u => u.Pseudo == pseudo));
            }
        }
        
        [Fact]
        public async Task GetAllArticleUsers_ReturnsCorrectUsers()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var userPseudo = "user1";
                var articleId = 1L;
                context.UserSet.Add(new UserEntity { Pseudo = userPseudo });
                context.ArticleUserSet.Add(new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = articleId });
                context.SaveChanges();

                var service = new DbManagerUser(context);

                // Act
                var users = await service.GetAllArticleUsers();

                // Assert
                Assert.Single(users);
                Assert.Contains(users, u => u.Pseudo == userPseudo);
            }
        }
        
          [Fact]
    public async Task GetArticleUser_ReturnsCorrectArticles()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var userPseudo = "userWithArticle";
            var articleId = 2L;
            context.UserSet.Add(new UserEntity { Pseudo = userPseudo });
            context.ArticleSet.Add(new ArticleEntity { Id = articleId, Title = "Test Article" });
            context.ArticleUserSet.Add(new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = articleId });
            context.SaveChanges();

            var service = new DbManagerUser(context);

            // Act
            var articles = await service.GetArticleUser(userPseudo);

            // Assert
            Assert.Single(articles);
            Assert.Contains(articles, a => a.Id == articleId);
        }
    }

    [Fact]
    public async Task CreateArticleUser_AddsRelationshipSuccessfully()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var userPseudo = "newUserForArticle";
            var articleId = 3L;
            context.UserSet.Add(new UserEntity { Pseudo = userPseudo });
            context.ArticleSet.Add(new ArticleEntity { Id = articleId, Title = "New Article" });
            context.SaveChanges();

            var service = new DbManagerUser(context);
            var newArticleUser = new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = articleId };

            // Act
            var success = await service.CreateArticleUser(newArticleUser);

            // Assert
            Assert.True(success);
            Assert.NotNull(context.ArticleUserSet.FirstOrDefault(au => au.UserEntityPseudo == userPseudo && au.ArticleEntityId == articleId));
        }
    }

    [Fact]
    public async Task DeleteArticleUser_RemovesRelationshipSuccessfully()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var userPseudo = "userToDeleteArticle";
            var articleId = 4L;
            context.UserSet.Add(new UserEntity { Pseudo = userPseudo });
            context.ArticleSet.Add(new ArticleEntity { Id = articleId });
            context.ArticleUserSet.Add(new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = articleId });
            context.SaveChanges();

            var service = new DbManagerUser(context);

            // Act
            var success = await service.DeleteArticleUser(userPseudo, articleId);

            // Assert
            Assert.True(success);
            Assert.DoesNotContain(context.ArticleUserSet, au => au.UserEntityPseudo == userPseudo && au.ArticleEntityId == articleId);
        }
    }

    [Fact]
    public async Task UpdateArticleUser_UpdatesRelationshipSuccessfully()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var userPseudo = "userToUpdateArticle";
            var originalArticleId = 5L;
            var newArticleId = 6L;
            context.UserSet.Add(new UserEntity { Pseudo = userPseudo });
            context.ArticleSet.Add(new ArticleEntity { Id = originalArticleId });
            context.ArticleSet.Add(new ArticleEntity { Id = newArticleId });
            context.ArticleUserSet.Add(new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = originalArticleId });
            context.SaveChanges();

            var service = new DbManagerUser(context);

            // Act
            var success = await service.DeleteArticleUser(userPseudo, originalArticleId);
            Assert.True(success);

            var updatedArticleUser = new ArticleUserEntity { UserEntityPseudo = userPseudo, ArticleEntityId = newArticleId };
            success = await service.CreateArticleUser(updatedArticleUser);

            // Assert
            Assert.True(success);
            var relationship = context.ArticleUserSet.FirstOrDefault(au => au.UserEntityPseudo == userPseudo);
            Assert.NotNull(relationship);
            Assert.Equal(newArticleId, relationship.ArticleEntityId);
        }
    }

}