using IntranetAPI.Contracts.V1.Requests.Auth;
using IntranetAPI.Services.AuthorizationServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IntranetAPI.Contracts.V1.ApiRoutes;

namespace IntranetAPI.Controllers.V1
{
    public class AuthorizationController : ControllerBase
    {
        private IAuthService _service;
        public AuthorizationController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost(Authorize.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _service.Login(request);
            if (response.Success != false)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost(Authorize.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _service.Register(request);
            if (response.Success != false)
            {
                return Ok(response);
            }    

            return BadRequest(response);
        }
    }
}
