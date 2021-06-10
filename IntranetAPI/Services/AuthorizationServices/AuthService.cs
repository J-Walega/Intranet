using IntranetAPI.Contracts.V1.Requests.Auth;
using IntranetAPI.Contracts.V1.Responses.Auth;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.AuthorizationServices
{
    public class AuthService : IAuthService
    {
        private IUserRepo _repo;
        public AuthService(IUserRepo repo)
        {
            _repo = repo;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = await _repo.GetUserByUsernameAsync(request.Username);
            if (response != null)
            {
                return new LoginResponse
                {
                    Success = true,
                    Token = "test"
                };
            }
            return new LoginResponse
            {
                Success = false,
                Error = "Wrong username or password"
            };
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var getUser = await _repo.GetUserByUsernameAsync(request.Username);
            if (getUser != null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Errors = new[] { "User exists" },
                };
            } 
            else
            {
                User user = new User
                {
                    Username = request.Username,
                    Password = request.Password,
                    Role = "user"
                };
                var register = await _repo.RegisterUserAsync(user);
                if (register != false)
                {
                    return new RegisterResponse
                    {
                        Success = true,
                        Token = "Test token"
                    };
                }
                return new RegisterResponse
                {
                    Success = false,
                    Errors = new[] { "Something went wrong" }
                };
            }
        }
    }
}
