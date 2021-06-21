using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Contracts.V1.Responses;
using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
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

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var file = await _repo.FindFileAsync(Id);
            if(file != null)
            {
                string filePath = file.Path.Replace('/', '\\');
                string fullPath = _enviroment.ContentRootPath + filePath;
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(fullPath);              
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }

                await _repo.DeleteAsync(Id);
                return new ServiceResult
                {
                    Success = true,
                    Errors = new[] { "Deleted" }
                };
            }
            return new ServiceResult
            {
                Success = false,
                Errors = new[] { "File with that Id doesn't exist" }
            };
        }

        public async Task<List<File>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<File>> GetByCategory(Category category)
        {
            return await _repo.GetByCategoryAsync(category);
        }

        public async Task<ServiceResult> UploadFileAsync(UploadFileRequest request)
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
                    await _repo.SaveAsync(file);
                    return new ServiceResult
                    {
                        Success = true
                    };
                }
                return new ServiceResult 
                {
                    Success = false,
                    Errors = new[] { "File with that title exists" }
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
