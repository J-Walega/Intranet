using IntranetAPI.Contracts.V1.Requests.Phone;
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

        public async Task<bool> AddPhone(AddPhoneRequest request)
        {
            Phone phone = new Phone
            {
                Name = request.Name,
                Number = request.Number
            };
            return await _repo.AddPhoneAsync(phone);
        }

        public async Task<List<Phone>> GetPhones()
        {
            return await _repo.GetPhonesAsync();
        }

        public async Task<bool> UpdatePhone(Phone phone)
        {
            return await _repo.UpdatePhoneAsync(phone);
        }
    }
}
