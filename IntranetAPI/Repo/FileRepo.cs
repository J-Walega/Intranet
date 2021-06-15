using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteFileAsync(int Id)
        {
            var file = _context.Files.Where(x => x.Id == Id).FirstOrDefault();
            _context.Remove(file);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveFileAsync(File file)
        {
            await _context.Files.AddAsync(file);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
