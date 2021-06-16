using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.PhonebookServecs
{
    public class PhonebookService : IPhonebookService
    {
        IPhoneRepo _repo;

        public PhonebookService(IPhoneRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Phone>> GetPhones()
        {
            return await _repo.GetPhonesAsync();
        }
    }
}
