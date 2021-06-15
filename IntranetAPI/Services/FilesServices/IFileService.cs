using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public interface IFileService
    {
        Task<bool> UploadAsync(UploadFileRequest request);
        Task<bool> DeleteAsync(int Id);
        Task<List<File>> GetAllAsync();
    }
}
