using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Responses.Auth
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
    }
}
