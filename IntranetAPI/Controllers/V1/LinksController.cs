using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Links;
using IntranetAPI.Services.LinksServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class LinksController : ControllerBase
    {
        private readonly ILinkService _service;

        public LinksController(ILinkService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.Links.GetLinks)]
        public async Task<IActionResult> GetLinks([FromRoute] string category)
        {
            if(category != string.Empty)
            {
                var content = await _service.GetLinksByCategory(category);
                return Ok(content);
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost(ApiRoutes.Links.AddLink)]
        public async Task<IActionResult> AddLink([FromBody] AddLinkRequest request)
        {
            if (TryValidateModel(request) == true)
            {
                var result = await _service.SaveLink(request);
                return Ok();
            }
            return BadRequest("Something went wrong");
        }
    }
}
