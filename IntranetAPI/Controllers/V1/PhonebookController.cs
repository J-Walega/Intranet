using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Phone;
using IntranetAPI.Entities;
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

        [HttpPost(ApiRoutes.Phonebook.Add)]
        public async Task<IActionResult> AddPhone([FromBody] AddPhoneRequest request)
        {
            var response = await _service.AddPhone(request);
            if(response != false)
            {
                return Ok("Created");
            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete(ApiRoutes.Phonebook.Delete)]
        public async Task<IActionResult> DeletePhone([FromRoute] int phoneId)
        {
            return BadRequest("not implemented");
        }

        [HttpPatch(ApiRoutes.Phonebook.Update)]
        public async Task<IActionResult> UpdatePhone([FromRoute] int phoneId, [FromBody] AddPhoneRequest request)
        {
            var phone = new Phone
            {
                Id = phoneId,
                Name = request.Name,
                Number = request.Number
            };

            return BadRequest("not implemented");
        }
    }
}
