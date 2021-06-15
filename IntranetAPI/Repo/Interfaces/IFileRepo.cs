using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo.Interfaces
{
    public interface IFileRepo
    {
        Task<bool> SaveFileAsync(File file);
        Task<bool> DeleteFileAsync(int Id);
        Task<List<File>> GetAllAsync();
    }
}
