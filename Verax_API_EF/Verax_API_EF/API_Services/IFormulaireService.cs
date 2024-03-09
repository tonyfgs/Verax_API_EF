using Model;

namespace API_Services;

public interface IFormulaireService
{

    Task<IEnumerable<Formulaire?>> GetAllForm(int index, int count, FormOrderCriteria orderCriteria);

    Task<Formulaire?> GetById(long id);
    
    
    Task<Formulaire?> CreateForm(Formulaire formulaire);

    Task<bool> DeleteForm(long id);

    Task<bool> UpdateForm(long id, Formulaire formulaire);
}