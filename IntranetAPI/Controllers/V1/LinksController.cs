using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Links;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class LinksController : ControllerBase
    {
        [HttpGet(ApiRoutes.Links.GetLinks)]
        public async Task<IActionResult> GetLinks([FromRoute] string Category)
        {
            return Ok(string.Empty);
        }

        [HttpPost(ApiRoutes.Links.AddLink)]
        public async Task<IActionResult> AddLink([FromBody] AddLinkRequest request)
        {
            return BadRequest("Not Implemented");
        }
    }
}
