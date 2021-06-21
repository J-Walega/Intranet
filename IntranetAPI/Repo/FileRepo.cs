using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
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

        public async Task<bool> DeleteAsync(int Id)
        {
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == Id);
            if(file != null)
            {
                _context.Remove(file);
                return await SaveChangesAsync();
            }
            return false;
        }

        public async Task<File> FindFileAsync(int Id)
        {
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == Id);
            return file;
        }

        public async Task<List<File>> GetAllAsync()
        {
            var files = await _context.Files.ToListAsync();
            return files;
        }

        public async Task<List<File>> GetByCategoryAsync(Category category)
        {
            var files = await _context.Files.Where(x => x.Category == category).ToListAsync();
            return files;
        }

        public async Task<bool> SaveAsync(File file)
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
