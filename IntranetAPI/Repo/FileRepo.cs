using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo
{
    public class FileRepo : IFileRepo
    {
        private readonly DataContext _context;
        public FileRepo(DataContext context)
        {
            _context = context;
        }

        public Task<bool> SaveFileAsync(File file)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
