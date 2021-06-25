using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Links;
using IntranetAPI.Services.LinksServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    [Authorize]
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
            var content = await _service.GetLinksByCategory(category);
            if(content.Count != 0)
            {
                return Ok(content);
            }
            return NoContent();
        }

        [HttpPost(ApiRoutes.Links.AddLink)]
        public async Task<IActionResult> AddLink([FromForm] AddLinkRequest request)
        {
            if (TryValidateModel(request) == true)
            {
                var result = await _service.SaveLink(request);
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }
    }
}
