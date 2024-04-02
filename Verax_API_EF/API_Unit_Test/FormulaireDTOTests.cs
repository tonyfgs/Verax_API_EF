using Web_API.Model;

namespace API_Unit_Test;

public class FormulaireDTOTests
{
    [Fact]
    public void PropertiesTest()
    {
        // Arrange
        var formulaire = new FormulaireDTO
        {
            Id = 1,
            Theme = "Test Theme",
            Date = "2024-03-16",
            Lien = "http://example.com",
            UserPseudo = "TestUser"
        };

        // Act & Assert
        Assert.Equal(1, formulaire.Id);
        Assert.Equal("Test Theme", formulaire.Theme);
        Assert.Equal("2024-03-16", formulaire.Date);
        Assert.Equal("http://example.com", formulaire.Lien);
        Assert.Equal("TestUser", formulaire.UserPseudo);
    }
}