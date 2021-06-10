using System.ComponentModel.DataAnnotations;

namespace IntranetAPI.Entities
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
