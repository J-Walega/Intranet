using IntranetAPI.Contracts.V1.Requests.Phone;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using System.Collections.Generic;
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
            Phone phone = new()
            {
                Name = request.Name,
                Number = request.Number
            };
            return await _repo.AddPhoneAsync(phone);
        }

        public async Task<bool> DeletePhone(int id)
        {
            return await _repo.DeletePhoneAsync(id);
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
