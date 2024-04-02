using API_Mapping;
using API.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using Web_API.Model;

namespace API_Unit_Test;

public class UserControllerTests
    {
        private readonly Mock<IDataManager> _mockDataManager;
        private readonly Mock<ILogger<UserController>> _mockLogger;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockDataManager = new Mock<IDataManager>();
            _mockLogger = new Mock<ILogger<UserController>>();
            _controller = new UserController(_mockDataManager.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            _mockDataManager.Setup(dm => dm.UserService.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<UserOrderCriteria>()))
                            .ReturnsAsync(new List<User>());

            var result = await _controller.GetAll();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetByPseudo_ReturnsOk()
        {
            var pseudo = "testUser";
            _mockDataManager.Setup(dm => dm.UserService.GetByPseudo(pseudo))
                            .ReturnsAsync(new User { Pseudo = pseudo });

            var result = await _controller.GetByPseudo(pseudo);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsOk()
        {
            var user = new User { Pseudo = "newUser" };
            _mockDataManager.Setup(dm => dm.UserService.Create(user))
                            .ReturnsAsync(user);

            var result = await _controller.Create(user);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsOk()
        {
            var pseudo = "existingUser";
            var user = new User { Pseudo = pseudo };
            _mockDataManager.Setup(dm => dm.UserService.Update(user, pseudo))
                            .ReturnsAsync(user);

            var result = await _controller.Update(user, pseudo);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOk()
        {
            var pseudo = "deleteUser";
            _mockDataManager.Setup(dm => dm.UserService.Delete(pseudo))
                            .ReturnsAsync(new User { Pseudo = pseudo });

            var result = await _controller.Delete(pseudo);

            Assert.IsType<OkObjectResult>(result);
        }
        

        [Fact]
        public async Task Create_ThrowsException_ReturnsBadRequest()
        {
            var user = new User { Pseudo = "errorUser" };
            _mockDataManager.Setup(dm => dm.UserService.Create(user))
                            .ThrowsAsync(new Exception("Test exception"));

            var result = await _controller.Create(user);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async Task CreateArticleUser_ReturnsOk_WithNewArticleUser()
        {
            // Arrange
            var articleUser = new ArticleUserEntity { UserEntityPseudo = "User1", ArticleEntityId = 1 };
            _mockDataManager.Setup(m => m.UserService.CreateArticleUser(articleUser)).ReturnsAsync(true);

            // Act
            var result = await _controller.CreateArticleUser(articleUser);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateArticleUser_ReturnsOk_WhenUpdated()
        {
            // Arrange
            var articleUser = new ArticleUserEntity { UserEntityPseudo = "User1", ArticleEntityId = 2 };
            _mockDataManager.Setup(m => m.UserService.DeleteArticleUser(It.IsAny<string>(), It.IsAny<long>())).ReturnsAsync(true);
            _mockDataManager.Setup(m => m.UserService.CreateArticleUser(It.IsAny<ArticleUserEntity>())).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateArticleUser(articleUser, 1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        
        [Fact]
        public async Task DeleteArticleUser_ReturnsOk_WhenDeleted()
        {
            // Arrange
            _mockDataManager.Setup(m => m.UserService.DeleteArticleUser(It.IsAny<string>(), It.IsAny<long>())).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteArticleUser("User1", 1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }