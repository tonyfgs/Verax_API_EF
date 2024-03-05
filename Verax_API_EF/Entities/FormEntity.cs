namespace Entities;

public class FormEntity
{
    public long Id { get; set; }
    public string Theme { get; set; } = string.Empty;
    public string DatePublication { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Pseudo { get; set; } = string.Empty;
    
    
    public long UserEntityId { get; set; }
    public UserEntity User { get; set; } = null;


}