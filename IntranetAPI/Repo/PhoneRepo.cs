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

        public async Task<bool> AddPhoneAsync(Phone phone)
        {
            await _context.Phones.AddAsync(phone);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeletePhoneAsync(int id)
        {
            var Phone = await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if(Phone != null)
            {
                _context.Remove(Phone);
                return await SaveChangesAsync();
            }
            return false;
        }

        public async Task<List<Phone>> GetPhonesAsync()
        {
            var phones = await _context.Phones.ToListAsync();
            return phones;
        }

        public async Task<bool> UpdatePhoneAsync(Phone phone)
        {
            _context.Entry(await _context.Phones
                .FirstOrDefaultAsync(x => x.Id == phone.Id))
                .CurrentValues.SetValues(phone);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
