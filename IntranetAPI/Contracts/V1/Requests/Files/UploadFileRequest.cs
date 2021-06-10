using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Requests.Files
{
    public class UploadFileRequest
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
