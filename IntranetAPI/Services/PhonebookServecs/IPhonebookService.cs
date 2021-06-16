using IntranetAPI.Contracts.V1.Requests.Phone;
using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.PhonebookServecs
{
    public interface IPhonebookService
    {
        Task<List<Phone>> GetPhones();
        Task<bool> AddPhone(AddPhoneRequest request);
        Task<bool> UpdatePhone(Phone phone);
    }
}
