using API_Mapping;
using Model;
using Web_API.Model;

namespace API_UnitTest_Mapper;

public class UserMappingTests
{
    [Fact]
    public void ToDTOMapsCorrectly()
    {
        // Arrange
        var user = new User
        {
            Pseudo = "testUser",
            Mdp = "testPassword",
            Nom = "Doe",
            Prenom = "John",
            Mail = "john.doe@example.com",
            Role = "User"
        };

        // Act
        var dto = UserMapping.ToDTO(user);

        // Assert
        Assert.NotNull(dto);
        Assert.Equal(user.Pseudo, dto.Pseudo);
        Assert.Equal(user.Mdp, dto.Mdp);
        Assert.Equal(user.Nom, dto.Nom);
        Assert.Equal(user.Prenom, dto.Prenom);
        Assert.Equal(user.Mail, dto.Mail);
        Assert.Equal(user.Role, dto.Role);
    }

    [Fact]
    public void ToModelMapsCorrectly()
    {
        // Arrange
        var dto = new UserDTO
        {
            Pseudo = "anotherTestUser",
            Mdp = "anotherTestPassword",
            Nom = "Smith",
            Prenom = "Jane",
            Mail = "jane.smith@example.com",
            Role = "Admin"
        };

        // Act
        var user = UserMapping.ToModel(dto);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(dto.Pseudo, user.Pseudo);
        Assert.Equal(dto.Mdp, user.Mdp);
        Assert.Equal(dto.Nom, user.Nom);
        Assert.Equal(dto.Prenom, user.Prenom);
        Assert.Equal(dto.Mail, user.Mail);
        Assert.Equal(dto.Role, user.Role);
    }

    [Fact]
    public void ToDTONullUserThrowsNullReferenceException()
    {
        // Arrange
        User user = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => UserMapping.ToDTO(user));
    }
    
    [Fact]
    public void ToModelNullUserDTOThrowsNullReferenceException()
    {
        // Arrange
        UserDTO dto = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => UserMapping.ToModel(dto));
    }
    
    [Fact]
    public void ToDTOMapsCorrectlyWithEmptyUser()
    {
        // Arrange
        var user = new User();

        // Act
        var dto = UserMapping.ToDTO(user);

        // Assert
        Assert.NotNull(dto);
        Assert.Equal(user.Pseudo, dto.Pseudo);
        Assert.Equal(user.Mdp, dto.Mdp);
        Assert.Equal(user.Nom, dto.Nom);
        Assert.Equal(user.Prenom, dto.Prenom);
        Assert.Equal(user.Mail, dto.Mail);
        Assert.Equal(user.Role, dto.Role);
    }
    
    [Fact]
    public void ToModelMapsCorrectlyWithEmptyUserDTO()
    {
        // Arrange
        var dto = new UserDTO();

        // Act
        var user = UserMapping.ToModel(dto);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(dto.Pseudo, user.Pseudo);
        Assert.Equal(dto.Mdp, user.Mdp);
        Assert.Equal(dto.Nom, user.Nom);
        Assert.Equal(dto.Prenom, user.Prenom);
        Assert.Equal(dto.Mail, user.Mail);
        Assert.Equal(dto.Role, user.Role);
    }
}