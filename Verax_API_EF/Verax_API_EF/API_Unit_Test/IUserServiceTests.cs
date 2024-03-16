using API_Services;
using Entities;
using Model;
using Moq;

namespace API_Unit_Test;

public class IUserServiceTests
{

    [Fact]
    static void TestAllUser()
    {
        var mockUserService = new Mock<IUserService>();
        var expected = new List<User>()
        {
            new User()
            {
                Pseudo = "Tofgasy",
                Prenom = "Tony",
                Nom = "Fages",
                Mail = "mail@mail.com",
                Mdp = "1234",
                Role = "Admin"
            },
            new User()
            {
                Pseudo = "Blizzard",
                Prenom = "Louis",
                Nom = "Laborie",
                Mail = "mail@mail.com",
                Mdp = "1234",
                Role = "Admin",
            }, 
        };
        mockUserService.Setup(x => x.GetAll(0, 10, UserOrderCriteria.None)).ReturnsAsync(expected);
        var result = mockUserService.Object.GetAll(0, 10, UserOrderCriteria.None);
        Assert.Equal(expected, result.Result);
        
    }

    [Fact]
    static void TestGetUserByPseudo()
    {
        var mockUserService = new Mock<IUserService>();
        var expected = new User()
        {
            Pseudo = "Tofgasy",
            Prenom = "Tony",
            Nom = "Fages",
            Mail = "mail@mail.com",
            Mdp = "1234",
            Role = "Admin"
        };
        mockUserService.Setup(x => x.GetByPseudo("Tofgasy")).ReturnsAsync(expected);
        var result = mockUserService.Object.GetByPseudo("Tofgasy");
        Assert.Equal(expected, result.Result);
    }

    [Fact]
    static void TestCreateUser()
    {
        var mockUserService = new Mock<IUserService>();
        var user = new User()
        {
            Pseudo = "Tofgasy",
            Prenom = "Tony",
            Nom = "Fages",
            Mail = "mail@mail.com",
            Mdp = "1234",
            Role = "Admin"
        };
        mockUserService.Setup(x => x.Create(user)).ReturnsAsync(user);
        var result = mockUserService.Object.Create(user);
        Assert.Equal( user,result.Result);
    }

    [Fact]
    static void TestUpdateUser()
    {
        var mockUserService = new Mock<IUserService>();
        var user = new User()
        {
            Pseudo = "Tofgasy",
            Prenom = "Tonio",
            Nom = "Fages",
            Mail = "mail@mail.com",
            Mdp = "1234",
            Role = "Admin"
        };
        mockUserService.Setup(x => x.Update(user, "Tofgasy")).ReturnsAsync(user);
        var result = mockUserService.Object.Update(user, "Tofgasy");
        Assert.Equal( user,result.Result);
    }
    
    [Fact]
    static void TestDeleteUser()
    {
        var mockUserService = new Mock<IUserService>();
        var user = new User()
        {
            Pseudo = "Tofgasy",
            Prenom = "Tonio",
            Nom = "Fages",
            Mail = "mail@mail.com",
            Mdp = "1234",
            Role = "Admin"
        };
        mockUserService.Setup(x => x.Delete("Tofgasy")).ReturnsAsync(user);
        var result = mockUserService.Object.Delete("Tofgasy");
        Assert.Equal( user,result.Result);
    }


    [Fact]
    static void TestGetAllArticleUsers()
    {
        var mockUserService = new Mock<IUserService>();
        var expected = new List<User>()
        {
            new User()
            {
                Pseudo = "Tofgasy",
                Prenom = "Tony",
                Nom = "Fages",
                Mail = "",
                Mdp = "",
                Role = "",
            },
            new User()
            {
                Pseudo = "Blizzard",
                Prenom = "Louis",
                Nom = "Laborie",
                Mail = "",
                Mdp = "",
                Role = "",
            },
        };
        mockUserService.Setup(x => x.GetAllArticleUsers()).ReturnsAsync(expected);
        var result = mockUserService.Object.GetAllArticleUsers();
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    static void TestGetArticleUser()
    {
        var mockUserService = new Mock<IUserService>();
        var expected = new List<Article>()
        {
            new Article()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 10
            },
            new Article()
            {
                Id = 2,
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 10
            }
        };
        mockUserService.Setup(x => x.GetArticleUser("Tofgasy")).ReturnsAsync(expected);
        var result = mockUserService.Object.GetArticleUser("Tofgasy");
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    static void TestCreateArticleUser()
    {
        var mockUserService = new Mock<IUserService>();
        var articleUser = new ArticleUserEntity()
        {
            ArticleEntityId = 1,
            UserEntityPseudo = "Tofgasy"
        };
        mockUserService.Setup(x => x.CreateArticleUser(articleUser)).ReturnsAsync(true);
        var result = mockUserService.Object.CreateArticleUser(articleUser);
        Assert.True(result.Result);
    }
    
    [Fact]
    static void TestDeleteArticleUser()
    {
        var mockUserService = new Mock<IUserService>();
        mockUserService.Setup(x => x.DeleteArticleUser("Tofgasy", 1)).ReturnsAsync(true);
        var result = mockUserService.Object.DeleteArticleUser("Tofgasy", 1);
        Assert.True(result.Result);
    }
    
    [Fact]
    static void TestUpdateArticleUser()
    {
        var mockUserService = new Mock<IUserService>();
        var articleUser = new ArticleUserEntity()
        {
            ArticleEntityId = 1,
            UserEntityPseudo = "Tofgasy"
        };
        mockUserService.Setup(x => x.UpdateArticleUser(articleUser)).ReturnsAsync(true);
        var result = mockUserService.Object.UpdateArticleUser(articleUser);
        Assert.True(result.Result);
    }



}

