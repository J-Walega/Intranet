using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Responses.Auth
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
