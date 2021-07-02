using IntranetAPI.Contracts.V1.Requests.Auth;
using IntranetAPI.Contracts.V1.Responses.Auth;
using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntranetAPI.Services.AuthorizationServices
{
    public class AuthService : IAuthService
    {
        private IUserRepo _repo;
        private IConfiguration _configuration;
        public AuthService(IUserRepo repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = await _repo.GetUserByUsernameAsync(request.Username);
            if (response != null)
            {
                return new LoginResponse
                {
                    Success = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(GenerateToken(response))
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
                User user = new()
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
                        Token = new JwtSecurityTokenHandler().WriteToken(GenerateToken(user))
                    };
                }
                return new RegisterResponse
                {
                    Success = false,
                    Errors = new[] { "Something went wrong" }
                };
            }
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
