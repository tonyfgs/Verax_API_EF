using System.ComponentModel.DataAnnotations;

namespace Entities;

public class FormEntity
{
    [Key]
    public long Id { get; set; }
    public string Theme { get; set; } = string.Empty;
    public string DatePublication { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    
    public string UserEntityPseudo{ get; set; }
    public UserEntity User { get; set; } = null!;

}