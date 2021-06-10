using IntranetAPI.Contracts.V1;
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
    }
}
