namespace Model;

public class Article
{
    public long Id;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DatePublished { get; set; } = string.Empty;
    public int LectureTime { get; set; } 
    public string Author { get; set; } = string.Empty;
}