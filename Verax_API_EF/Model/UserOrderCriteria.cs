using System.Text.Json.Serialization;

namespace Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserOrderCriteria
{
    None, ByFirstName, ByLastName
}