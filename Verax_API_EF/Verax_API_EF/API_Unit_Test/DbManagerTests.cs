using DbContextLib;
using DbDataManager;
using Moq;

namespace API_Unit_Test;

public class DbManagerTests
{
    [Fact]
    public void Constructor_WithoutParameters_InitializesServices()
    {
        // Arrange & Act
        var dbManager = new DbManager();

        // Assert
        Assert.NotNull(dbManager.ArticleService);
        Assert.NotNull(dbManager.UserService);
        Assert.NotNull(dbManager.FormulaireService);
    }

    [Fact]
    public void Constructor_WithLibraryContextParameter_InitializesServicesWithGivenContext()
    {
        // Arrange
        var context = new Mock<LibraryContext>().Object;

        // Act
        var dbManager = new DbManager(context);

        // Assert
        Assert.NotNull(dbManager.ArticleService);
        Assert.NotNull(dbManager.UserService);
        Assert.NotNull(dbManager.FormulaireService);
    }
}