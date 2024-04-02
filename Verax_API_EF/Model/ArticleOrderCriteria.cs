using System.Text.Json.Serialization;

namespace Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ArticleOrderCriteria
{
    None, ByTitle, ByAuthor, ByLectureTime, ByDatePublished, ByDescription
}