using Model;

namespace API_Services;

public interface IFormulaireService
{

    Task<IEnumerable<Formulaire?>> GetAllForm(int index, int count, FormOrderCriteria orderCriteria);

    Task<Formulaire?> GetById(long id);
    
    
    Task<Formulaire?> CreateForm(Formulaire formulaire);

    Task<Formulaire?> DeleteForm(long id);

    Task<Formulaire?> UpdateForm(long id, Formulaire formulaire);
}