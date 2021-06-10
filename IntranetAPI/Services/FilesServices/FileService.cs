using IntranetAPI.Contracts.V1.Requests.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public class FileService : IFileService
    {
        public Task<bool> UploadFileAsync(UploadFileRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
