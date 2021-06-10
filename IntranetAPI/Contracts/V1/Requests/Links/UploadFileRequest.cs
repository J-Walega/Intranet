using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Requests.Links
{
    public class UploadFileRequest
    {
        public IFormFile File { get; set; }
        public string Category { get; set; }
    }
}
