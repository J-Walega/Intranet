using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.FilesServices
{
    public class FileService : IFileService
    {
        private IFileRepo _repo;

        public FileService(IFileRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> UploadFileAsync(UploadFileRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
