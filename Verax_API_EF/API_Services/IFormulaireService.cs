using Model;

namespace API_Services;

public interface IFormulaireService
{

    Task<IEnumerable<Formulaire?>> GetAllForm();

    Task<Formulaire?> GetById(long id);
    
    
    Task<Formulaire?> CreateForm(Formulaire formulaire);

    Task<bool> DeleteForm(long id);

    Task<bool> UpdateForm(long id, Formulaire formulaire);
}