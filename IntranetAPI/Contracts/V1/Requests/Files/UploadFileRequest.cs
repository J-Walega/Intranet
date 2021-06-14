using IntranetAPI.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IntranetAPI.Contracts.V1.Requests.Files
{
    public class UploadFileRequest
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
