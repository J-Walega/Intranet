using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Contracts.V1.Responses;
using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public interface IFileService
    {
        Task<ServiceResult> UploadFileAsync(UploadFileRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<List<File>> GetAllAsync();
        Task<List<File>> GetByCategory(Category category);
    }
}
