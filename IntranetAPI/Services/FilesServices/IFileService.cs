using IntranetAPI.Contracts.V1.Requests.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(UploadFileRequest request);
        Task<bool> DeleteFileAsync(int Id);
    }
}
