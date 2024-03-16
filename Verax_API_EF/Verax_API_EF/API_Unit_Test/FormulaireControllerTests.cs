using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;

namespace API_Unit_Test;

public class FormulaireControllerTests
    {
        private readonly Mock<IDataManager> _mockDataManager;
        private readonly Mock<ILogger<FormulaireController>> _mockLogger;
        private readonly FormulaireController _controller;

        public FormulaireControllerTests()
        {
            _mockDataManager = new Mock<IDataManager>();
            _mockLogger = new Mock<ILogger<FormulaireController>>();
            _controller = new FormulaireController(_mockDataManager.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllForm_ReturnsOk()
        {
            // Arrange
            _mockDataManager.Setup(dm => dm.FormulaireService.GetAllForm(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<FormOrderCriteria>()))
                            .ReturnsAsync(new List<Formulaire>());

            // Act
            var result = await _controller.GetAllForm();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOk()
        {
            // Arrange
            var testFormId = 1L;
            _mockDataManager.Setup(dm => dm.FormulaireService.GetById(testFormId))
                            .ReturnsAsync(new Formulaire { Id = testFormId });

            // Act
            var result = await _controller.GetById(testFormId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateForm_ReturnsOk()
        {
            // Arrange
            var form = new Formulaire { Theme = "Test" };
            _mockDataManager.Setup(dm => dm.FormulaireService.CreateForm(form))
                            .ReturnsAsync(form);

            // Act
            var result = await _controller.CreateForm(form);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteForm_ReturnsOk()
        {
            // Arrange
            var testFormId = 1L;
            _mockDataManager.Setup(dm => dm.FormulaireService.DeleteForm(testFormId))
                            .ReturnsAsync(new Formulaire { Id = testFormId });

            // Act
            var result = await _controller.DeleteForm(testFormId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateForm_ReturnsOk()
        {
            // Arrange
            var testFormId = 1L;
            var form = new Formulaire { Theme = "Updated" };
            _mockDataManager.Setup(dm => dm.FormulaireService.UpdateForm(testFormId, form))
                            .ReturnsAsync(form);

            // Act
            var result = await _controller.UpdateForm(testFormId, form);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllForm_ThrowsException_ReturnsBadRequest()
        {
            // Arrange
            _mockDataManager.Setup(dm => dm.FormulaireService.GetAllForm(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<FormOrderCriteria>()))
                            .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAllForm();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }