using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo
{
    public class PhoneRepo : IPhoneRepo
    {
        private readonly DataContext _context;

        public PhoneRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Phone>> GetPhonesAsync()
        {
            var phones = await _context.Phones.ToListAsync();
            return phones;
        }
    }
}
