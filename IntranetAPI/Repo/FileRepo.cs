﻿using IntranetAPI.Contracts.V1.Requests.Files;
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
            context = _context;
        }

        public async Task<bool> SaveFileAsync(File file)
        {
            await _context.AddAsync(file);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
