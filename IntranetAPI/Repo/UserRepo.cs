using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
            x.Username == username);
            return user;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
