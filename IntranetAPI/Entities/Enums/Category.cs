using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntranetAPI.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        Placeholder,
        [Display(Name = "BHP")]
        BHP,
        [Display(Name = "Instrukcje")]
        Instrukcje,
        [Display(Name = "Zarzadzenia")]
        Zarzadzenia,
    }
}
