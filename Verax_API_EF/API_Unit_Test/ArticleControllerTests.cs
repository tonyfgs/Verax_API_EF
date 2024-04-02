using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;

namespace API_Unit_Test;

public class ArticleControllerTests
    {
        private readonly Mock<IDataManager> _mockDataManager;
        private readonly Mock<ILogger<ArticleController>> _mockLogger;
        private readonly ArticleController _controller;

        public ArticleControllerTests()
        {
            _mockDataManager = new Mock<IDataManager>();
            _mockLogger = new Mock<ILogger<ArticleController>>();
            _controller = new ArticleController(_mockDataManager.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllArticles_ReturnsOk()
        {
            // Arrange
            _mockDataManager.Setup(dm => dm.ArticleService.GetAllArticles(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ArticleOrderCriteria>()))
                            .ReturnsAsync(new List<Article>());

            // Act
            var result = await _controller.GetAllArticles();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetArticleById_ReturnsOk()
        {
            // Arrange
            var testArticleId = 1;
            _mockDataManager.Setup(dm => dm.ArticleService.GetArticleById(testArticleId))
                            .ReturnsAsync(new Article { Id = testArticleId });

            // Act
            var result = await _controller.GetArticleById(testArticleId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateArticle_ReturnsOk()
        {
            // Arrange
            var article = new Article { Title = "Test" };
            _mockDataManager.Setup(dm => dm.ArticleService.CreateArticle(article))
                            .ReturnsAsync(article);

            // Act
            var result = await _controller.CreateArticle(article);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteArticle_ReturnsOk()
        {
            // Arrange
            var testArticleId = 1;
            _mockDataManager.Setup(dm => dm.ArticleService.DeleteArticle(testArticleId))
                            .ReturnsAsync(new Article { Id = testArticleId });

            // Act
            var result = await _controller.DeleteArticle(testArticleId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateArticle_ReturnsOk()
        {
            // Arrange
            var testArticleId = 1;
            var article = new Article { Title = "Updated" };
            _mockDataManager.Setup(dm => dm.ArticleService.UpdateArticle(testArticleId, article))
                            .ReturnsAsync(article);

            // Act
            var result = await _controller.UpdateArticle(testArticleId, article);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllArticles_ThrowsException_ReturnsBadRequest()
        {
            // Arrange
            _mockDataManager.Setup(dm => dm.ArticleService.GetAllArticles(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ArticleOrderCriteria>()))
                            .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAllArticles();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }