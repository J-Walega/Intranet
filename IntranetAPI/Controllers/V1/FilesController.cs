using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class FilesController : ControllerBase
    {
        [HttpPost(ApiRoutes.Files.Upload)]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
        {
            return BadRequest("Not implemented");
        }
    }
}
