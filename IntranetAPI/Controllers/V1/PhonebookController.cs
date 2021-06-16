using IntranetAPI.Contracts.V1;
using IntranetAPI.Services.PhonebookServecs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class PhonebookController : ControllerBase
    {
        IPhonebookService _service;
        public PhonebookController(IPhonebookService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.Phonebook.GetAll)]
        public async Task<IActionResult> GetAllPhones()
        {
            var response = await _service.GetPhones();
            return Ok(response);
        }
    }
}
