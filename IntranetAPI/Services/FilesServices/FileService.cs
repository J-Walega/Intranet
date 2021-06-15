using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public class FileService : IFileService
    {
        private readonly IFileRepo _repo;
        private readonly IWebHostEnvironment _enviroment;

        public FileService(IFileRepo repo, IWebHostEnvironment enviroment)
        {
            _repo = repo;
            _enviroment = enviroment;
        }

        public async Task<bool> DeleteFileAsync(int Id)
        {
            return await _repo.DeleteFileAsync(Id);
        }

        public async Task<List<File>> GetAllFilesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<bool> UploadFileAsync(UploadFileRequest request)
        {
            try
            {
                var file = new File
                {
                    Description = request.Description,
                    Category = request.Category,
                    Path = $"/Uploads/{request.Category}/{request.File.FileName}"
                };
                System.IO.Directory.CreateDirectory($"Uploads//{request.Category}");
                string path = _enviroment.ContentRootPath + "\\Uploads\\" + request.Category + "\\" + request.File.FileName;
                var info = new System.IO.FileInfo(path);
              
                if (!info.Exists)
                {
                    using System.IO.FileStream fileStream = System.IO.File.Create(path);
                    await request.File.CopyToAsync(fileStream);
                    fileStream.Flush();
                    // Uncomment to save in DB
                    // await _repo.SaveFileAsync(file);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
