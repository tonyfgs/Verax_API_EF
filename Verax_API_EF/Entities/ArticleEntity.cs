using System.ComponentModel.DataAnnotations;

namespace Entities;

public class ArticleEntity
{
    [Key]
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DatePublished { get; set; } = string.Empty;
    public int LectureTime { get; set; } 
    public string Author { get; set; } = string.Empty;

    public ICollection<UserEntity> Users { get; } = new List<UserEntity>();

}