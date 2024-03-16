using API_Mapping;
using Model;
using Web_API.Model;

namespace API_UnitTest_Mapper;

public class FormMapperTests
{
    [Fact]
    public void ToDTOMapsCorrectly()
    {
        var formulaire = new Formulaire
        {
            Id = 1,
            Theme = "Test Theme",
            Date = "2021-01-01",
            Lien = "http://example.com",
            UserPseudo = "TestUser"
        };

        var dto = FormulaireMapping.ToDTO(formulaire);

        Assert.NotNull(dto);
        Assert.Equal(formulaire.Id, dto.Id);
        Assert.Equal(formulaire.Theme, dto.Theme);
        Assert.Equal(formulaire.Date, dto.Date);
        Assert.Equal(formulaire.Lien, dto.Lien);
        Assert.Equal(formulaire.UserPseudo, dto.UserPseudo);
    }

    [Fact]
    public void ToModelMapsCorrectly()
    {
        var dto = new FormulaireDTO
        {
            Id = 2,
            Theme = "Another Test Theme",
            Date = "2021-01-02",
            Lien = "http://anotherexample.com",
            UserPseudo = "AnotherTestUser"
        };

        var formulaire = FormulaireMapping.ToModel(dto);

        Assert.NotNull(formulaire);
        Assert.Equal(dto.Id, formulaire.Id);
        Assert.Equal(dto.Theme, formulaire.Theme);
        Assert.Equal(dto.Date, formulaire.Date);
        Assert.Equal(dto.Lien, formulaire.Lien);
        Assert.Equal(dto.UserPseudo, formulaire.UserPseudo);
    }

    [Fact]
    public void ToDTONullFormulaireThrowsNullReferenceException()
    {
        Formulaire formulaire = null;

        Assert.Throws<NullReferenceException>(() => FormulaireMapping.ToDTO(formulaire));
    }
    
    [Fact]
    public void ToModelNullFormulaireDTOThrowsNullReferenceException()
    {
        FormulaireDTO dto = null;

        Assert.Throws<NullReferenceException>(() => FormulaireMapping.ToModel(dto));
    }
    
    
}