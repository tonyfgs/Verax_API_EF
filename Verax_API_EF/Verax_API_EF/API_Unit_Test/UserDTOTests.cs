using Web_API.Model;

namespace API_Unit_Test;

public class UserDTOTests
{
    [Fact]
    public void UserDTOPropertiesTest()
    {
        // Arrange
        var user = new UserDTO
        {
            Pseudo = "user1",
            Mdp = "password",
            Nom = "Doe",
            Prenom = "John",
            Mail = "john.doe@example.com",
            Role = "Admin"
        };

        // Act & Assert
        Assert.Equal("user1", user.Pseudo);
        Assert.Equal("password", user.Mdp);
        Assert.Equal("Doe", user.Nom);
        Assert.Equal("John", user.Prenom);
        Assert.Equal("john.doe@example.com", user.Mail);
        Assert.Equal("Admin", user.Role);
    }
}