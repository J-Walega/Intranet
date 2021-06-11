using System.Text.Json.Serialization;

namespace IntranetAPI.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        BHP,
        Instrukcje,
        Zarzadzenia,
        Inne,
    }
}
