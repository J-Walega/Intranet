using IntranetAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace IntranetAPI.Entities
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Category Category { get; set; }
    }
}
