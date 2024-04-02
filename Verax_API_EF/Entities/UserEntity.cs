using System.ComponentModel.DataAnnotations;

namespace Entities;

public class UserEntity
{
    [Key]
    public string Pseudo {  get; set; } = string.Empty;

    public string Mdp { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string Mail { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public ICollection<ArticleEntity> Articles { get; set; } = new List<ArticleEntity>();
    
    public ICollection<FormEntity> Forms { get; set; } = new List<FormEntity>();
}