using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo.Interfaces
{
    public interface IPhoneRepo
    {
        Task<List<Phone>> GetPhonesAsync();
        Task<bool> AddPhoneAsync(Phone phone);
        Task<bool> UpdatePhoneAsync(Phone phone);
    }
}
