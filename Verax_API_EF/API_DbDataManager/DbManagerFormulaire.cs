using API_Services;
using DbContextLib;
using Entities;
using Model;

namespace DbDataManager;

public class DbManagerFormulaire(LibraryContext _context) : IFormulaireService
{
    public async Task<IEnumerable<Formulaire?>> GetAllForm()
    {
        return await Task.FromResult(_context.FormSet.Select(f => f.ToModel()).AsEnumerable());
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