using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Entities
{
    public class File
    {
        public File()
        {
            UploadDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
