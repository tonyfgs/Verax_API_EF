using System.Text.Json.Serialization;

namespace Model;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum FormOrderCriteria
{
    None, ByTheme, ByDate, ByPseudo, ByLien
}