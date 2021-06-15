using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
using IntranetAPI.Services.FilesServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class FilesController : ControllerBase
    {
        private readonly IFileService _service;

        public FilesController(IFileService service)
        {
            _service = service;
        }

        [HttpPost(ApiRoutes.Files.Upload)]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
        {
            var result = await _service.UploadAsync(request);
            if(result!=true)
            {
                return BadRequest("File with that name already exists");
            }
            return Ok("Created");
        }

        [HttpDelete(ApiRoutes.Files.Delete)]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result = await _service.DeleteAsync(id);
            if(result!=true)
            {
                return BadRequest("Something went wrong");
            }
            return NoContent();
        }
        [HttpGet(ApiRoutes.Files.GetAll)]
        public async Task<IActionResult> GetAllFiles()
        {
            var result = await _service.GetAllAsync();
            if(result?.Any() == false)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Files.GetByCategory)]
        public async Task<IActionResult> GetFilesByCategory([FromRoute] Category category)
        {
            var result = await _service.GetByCategory(category);
            if(result?.Any() == false)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
