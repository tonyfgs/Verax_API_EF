using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerFormulaire : IFormulaireService
{
    
    private readonly LibraryContext _context;

    public DbManagerFormulaire(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Formulaire?>> GetAllForm(int index, int count, FormOrderCriteria orderCriteria)
    {
        List<Formulaire> formulaireList = new List<Formulaire>();
        switch (orderCriteria)
        {
            case FormOrderCriteria.None:
                formulaireList = _context.FormSet.Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByTheme:
                formulaireList = _context.FormSet.OrderBy(f => f.Theme).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByLien:
                formulaireList = _context.FormSet.OrderBy(f => f.Link).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByDate:
                formulaireList = _context.FormSet.OrderBy(f => f.DatePublication).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByPseudo:
                formulaireList = _context.FormSet.OrderBy(f => f.Pseudo).Select(f => f.ToModel()).ToList();
                break;
            default:
                formulaireList = _context.FormSet.Select(f => f.ToModel()).ToList();
                break;
        }
        return await Task.FromResult(formulaireList.AsEnumerable());
    }

    public async Task<Formulaire?> GetById(long id)
    {
        var entity = _context.FormSet.FirstOrDefault(f => f.Id == id);
        if (entity != null) return await Task.FromResult(entity.ToModel());
        return null;
    }

    public async Task<Formulaire?> CreateForm(Formulaire formulaire)
    {
        var entity = new FormEntity()
        {
            Id = formulaire.Id,
            Pseudo = formulaire.Pseudo,
            Theme = formulaire.Theme,
            DatePublication = formulaire.Date
        };
        
        _context.FormSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToModel();
    }

    public async Task<bool> DeleteForm(long id)
    {
        var entity = _context.FormSet.FirstOrDefault(f => f.Id == id);
        if (entity == null) return false;
        _context.FormSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateForm(long id, Formulaire formulaire)
    {
        var entity = _context.FormSet.FirstOrDefault(f => f.Id == id);
        if (entity == null) return false;
        entity.Pseudo = formulaire.Pseudo;
        entity.Theme = formulaire.Theme;
        entity.DatePublication = formulaire.Date;
        await _context.SaveChangesAsync();
        return true;
    }
}