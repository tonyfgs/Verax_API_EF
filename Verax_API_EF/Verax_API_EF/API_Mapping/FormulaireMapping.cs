using Model;
using Web_API.Model;

namespace API_Mapping;

public static class FormulaireMapping
{
    public static FormulaireDTO ToDTO(this Formulaire? f) => new()
    {
        Id = f.Id,
        Theme = f.Theme,
        Date = f.Date,
        Lien = f.Lien,
        UserPseudo = f.UserPseudo
    };
    
    public static Formulaire ToModel(this FormulaireDTO f) => new()
    {
        Id = f.Id,
        Theme = f.Theme,
        Date = f.Date,
        Lien = f.Lien,
        UserPseudo = f.UserPseudo
    };
}