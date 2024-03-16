using API_Services;
using Model;
using Moq;

namespace API_Unit_Test;

public class IFormServiceTests
{
    [Fact]
    public void TestGetAllForm()
    {
        var mockFormService = new Mock<IFormulaireService>();
        var expected = new List<Formulaire>()
        {
            new Formulaire()
            {
                Lien = "Test",
                Theme = "Test",
                Date = "Test",
                UserPseudo = "Test"
            },
            new Formulaire()
            {
                Lien = "Test",
                Theme = "Test",
                Date = "Test",
                UserPseudo = "Test"
            }
        };
        mockFormService.Setup(x => x.GetAllForm(0, 10, FormOrderCriteria.None)).ReturnsAsync(expected);
        var result = mockFormService.Object.GetAllForm(0, 10, FormOrderCriteria.None);
        Assert.Equal(expected, result.Result);
    }

    [Fact]
    public void TestGetFormById()
    {
        var mockFormService = new Mock<IFormulaireService>();
        var expected = new Formulaire()
        {
            Lien = "Test",
            Theme = "Test",
            Date = "Test",
            UserPseudo = "Test"
        };
        mockFormService.Setup(x => x.GetById(1)).ReturnsAsync(expected);
        var result = mockFormService.Object.GetById(1);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void TestCreateForm()
    {
        var mockFormService = new Mock<IFormulaireService>();
        var expected = new Formulaire()
        {
            Lien = "Test",
            Theme = "Test",
            Date = "Test",
            UserPseudo = "Test"
        };
        mockFormService.Setup(x => x.CreateForm(expected)).ReturnsAsync(expected);
        var result = mockFormService.Object.CreateForm(expected);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void TestUpdateForm()
    {
        var mockFormService = new Mock<IFormulaireService>();
        var expected = new Formulaire()
        {
            Lien = "Test",
            Theme = "Test",
            Date = "Test",
            UserPseudo = "Test"
        };
        mockFormService.Setup(x => x.CreateForm(expected)).ReturnsAsync(expected);
        var result = mockFormService.Object.CreateForm(expected);
        Assert.Equal(expected, result.Result);
    }
    
    [Fact]
    public void TestDeleteForm()
    {
        var mockFormService = new Mock<IFormulaireService>();
        var expected = new Formulaire()
        { 
            Lien = "Test",
            Theme = "Test",
            Date = "Test",
            UserPseudo = "Test"
        };
        mockFormService.Setup(x => x.DeleteForm(1)).ReturnsAsync(expected);
        var result = mockFormService.Object.DeleteForm(1);
        Assert.Equal(expected, result.Result);
    }

}