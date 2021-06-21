using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo.Interfaces
{
    public interface IFileRepo
    {
        Task<bool> SaveAsync(File file);
        Task<bool> DeleteAsync(int Id);
        Task<List<File>> GetAllAsync();
        Task<List<File>> GetByCategoryAsync(Category category);
        Task<File> FindFileAsync(int Id);
    }
}
