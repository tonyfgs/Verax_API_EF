using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerFormulaire : IFormulaireService
{
    
    private readonly LibraryContext _context;

    public DbManagerFormulaire(LibraryContext context)
        => this._context = context;

    public async Task<IEnumerable<Formulaire?>> GetAllForm(int index, int count, FormOrderCriteria orderCriteria)
    {
        List<Formulaire> formulaireList = new List<Formulaire>();
        switch (orderCriteria)
        {
            case FormOrderCriteria.None:
                formulaireList = _context.FormSet.Skip(index * count).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByTheme:
                formulaireList = _context.FormSet.Skip(index * count).OrderBy(f => f.Theme).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByLien:
                formulaireList = _context.FormSet.Skip(index * count).OrderBy(f => f.Link).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByDate:
                formulaireList = _context.FormSet.Skip(index * count).OrderBy(f => f.DatePublication).Select(f => f.ToModel()).ToList();
                break;
            case FormOrderCriteria.ByPseudo:
                formulaireList = _context.FormSet.Skip(index * count).OrderBy(f => f.UserEntityPseudo).Select(f => f.ToModel()).ToList();
                break;
            default:
                formulaireList = _context.FormSet.Skip(index * count).Select(f => f.ToModel()).ToList();
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
            Link = formulaire.Lien,
            Theme = formulaire.Theme,
            DatePublication = formulaire.Date,
            UserEntityPseudo = formulaire.UserPseudo
        };
        
        _context.FormSet.Add(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Formulaire?>(null);
        return entity.ToModel();
    }

    public async Task<Formulaire?> DeleteForm(long id)
    {
        var entity = _context.FormSet.FirstOrDefault(f => f.Id == id);
        if (entity == null) return Task.FromResult<Formulaire?>(null).Result;
        _context.FormSet.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Formulaire?>(null);
        return entity.ToModel();
    }

    public async Task<Formulaire?> UpdateForm(long id, Formulaire formulaire)
    {
        var entity = _context.FormSet.FirstOrDefault(f => f.Id == id);
        if (entity == null) return Task.FromResult<Formulaire?>(null).Result;
        entity.Theme = formulaire.Theme;
        entity.DatePublication = formulaire.Date;
        entity.Link = formulaire.Lien;
        entity.UserEntityPseudo = formulaire.UserPseudo;
        var result = await _context.SaveChangesAsync();
        if (result == 0) return await Task.FromResult<Formulaire?>(null);
        return entity.ToModel();
    }
}