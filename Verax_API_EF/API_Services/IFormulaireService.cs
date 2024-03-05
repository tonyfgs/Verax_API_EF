using Web_API.Model;

namespace API_Services;

public interface IFormulaireService
{

    Task<List<FormulaireDTO>> GetAllForm();

    Task<FormulaireDTO?> GetById(long id);
    
    
    Task<FormulaireDTO> CreateForm(Formulaire formulaire);

    Task<bool> DeleteForm(long id);

    Task<bool> UpdateForm(long id, Formulaire formulaire);
}